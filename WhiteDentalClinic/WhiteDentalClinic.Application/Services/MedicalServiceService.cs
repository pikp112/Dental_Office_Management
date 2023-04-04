using AutoMapper;
using WhiteDentalClinic.Application.Exceptions;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;
using WhiteDentalClinic.Shared.Services;

namespace WhiteDentalClinic.Application.Services
{
    public class MedicalServiceService : IMedicalServiceService
    {
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;
        private readonly IMedicalServiceRepository _medicalServiceRepository;
        private readonly IDentistServiceRepository _dentistServiceRepository;
        public MedicalServiceService(
            IMedicalServiceRepository medicalServiceRepository, 
            IMapper mapper, 
            IClaimService claimService,
            IDentistServiceRepository dentistServiceRepository) 
        {
            _medicalServiceRepository= medicalServiceRepository;
            _mapper = mapper;
            _claimService = claimService;
            _dentistServiceRepository = dentistServiceRepository;
        }
        public IEnumerable<ResponseMedicalServices> GetAll()
        {
            var listMedicalServices = _medicalServiceRepository.GetAll();
            return _mapper.Map<IEnumerable<ResponseMedicalServices>>(listMedicalServices);
        }

        public IEnumerable<ResponseMedicalServices> GetAllByDentistId(Guid requestDentistId)
        {
            //to delete? is something in DentistService
            //medical services by input dentist ID
            var listMedicalServicesById = _dentistServiceRepository.GetAll().Where(x => x.DentistId == requestDentistId);

            var tempId = listMedicalServicesById.Select(x => x.MedicalServiceId).ToList(); //list ID medical services

            var tempListMedicalService = new List<MedicalService>();

            foreach(var item in _medicalServiceRepository.GetAll().ToList())
            {
                foreach(var id in tempId)
                {
                    if(item.Id == id)
                    {
                        tempListMedicalService.Add(item);
                    }
                
                }
            }

            return _mapper.Map<IEnumerable<ResponseMedicalServices>>(tempListMedicalService);

            /*            var listMedicalServices = _medicalServiceRepository.GetAll().Where(x => x.Id == requestDentistId);
                        return _mapper.Map<IEnumerable<ResponseMedicalServices>>(listMedicalServices);
            */
        }

        public ResponseMedicalServices Create(RequestCreateMedicalService requestMedicalServiceModel)
        {
            var newMedicalService = _mapper.Map<MedicalService>(requestMedicalServiceModel);
            newMedicalService.Id = Guid.NewGuid();
            _medicalServiceRepository.AddEntity(newMedicalService);
            return _mapper.Map<ResponseMedicalServices>(newMedicalService);
        }

        public ResponseMedicalServices Delete(Guid id)
        {
            var medicaServiceById = _medicalServiceRepository.GetAll().FirstOrDefault(ms => ms.Id == id);
            _medicalServiceRepository.DeleteEntity(medicaServiceById);
            return _mapper.Map<ResponseMedicalServices>(medicaServiceById);

        }


        public ResponseUpdateMedicalService Update(Guid id, RequestUpdateMedicalService updateMedicalServiceModel)
        {
            var selectedMedicalService = _medicalServiceRepository.GetAll().FirstOrDefault(x => x.Id == id);

            var medicalServiceId = _claimService.GetUserId();
            if (medicalServiceId != selectedMedicalService.Id.ToString())
            {
                throw new BadRequestException("You can update only your email.");
            }

            selectedMedicalService.Price = updateMedicalServiceModel.Price;

            return new ResponseUpdateMedicalService
            {
                Id = _medicalServiceRepository.UpdateEntity(selectedMedicalService).Id
            };

        }
    }
}
