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
        public IEnumerable<ResponseMedicalServices> GetAllMedicalServices()
        {
            var listMedicalServices = _medicalServiceRepository.GetAll();
            return _mapper.Map<IEnumerable<ResponseMedicalServices>>(listMedicalServices);
        }

        public IEnumerable<ResponseMedicalServices> GetAllMedicalServicesByDentistId(Guid requestDentistId)
        {
            //medical services by input dentist ID
            var listMedicalServicesById = _dentistServiceRepository.GetAll().Where(x => x.dentistId == requestDentistId);

            var tempId = listMedicalServicesById.Select(x => x.medicalServiceId).ToList(); //list ID medical services

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

        public ResponseMedicalServices CreateAMedicalService(CreateMedicalService requestMedicalServiceModel)
        {
            var newMedicalService = _mapper.Map<MedicalService>(requestMedicalServiceModel);
            newMedicalService.Id = Guid.NewGuid();
            _medicalServiceRepository.AddEntity(newMedicalService);
            return _mapper.Map<ResponseMedicalServices>(newMedicalService);
        }

        public ResponseMedicalServices DeleteMedicalService(Guid id)
        {
            var medicaServiceById = _medicalServiceRepository.GetAll().FirstOrDefault(ms => ms.Id == id);
            _medicalServiceRepository.DeleteEntity(medicaServiceById);
            return _mapper.Map<ResponseMedicalServices>(medicaServiceById);

        }

        public UpdateResponseMedicalService UpdateMedicalService(Guid id, UpdateRequestMedicalService updateMedicalServiceModel)
        {
            var selectedMedicalService = _medicalServiceRepository.GetAll().FirstOrDefault(x => x.Id == id);

            var medicalServiceId = _claimService.GetUserId();
            if (medicalServiceId != selectedMedicalService.Id.ToString())
            {
                throw new BadRequestException("You can update only your email.");
            }

            selectedMedicalService.Price = updateMedicalServiceModel.Price;

            return new UpdateResponseMedicalService
            {
                Id = _medicalServiceRepository.UpdateEntity(selectedMedicalService).Id
            };

        }
    }
}
