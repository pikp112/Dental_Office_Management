using AutoMapper;
using WhiteDentalClinic.Application.Exceptions;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;
using WhiteDentalClinic.DataAccess.Repositories.MedicalServiceRepository;
using WhiteDentalClinic.Shared.Services;

namespace WhiteDentalClinic.Application.Services
{
    public class MedicalServiceService : IMedicalServiceService
    {
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;
        private readonly IMedicalServiceRepository _medicalServiceRepository;
        public MedicalServiceService(IMedicalServiceRepository medicalServiceRepository, IMapper mapper, IClaimService claimService) 
        {
            _medicalServiceRepository= medicalServiceRepository;
            _mapper = mapper;
            _claimService = claimService;
        }
        public IEnumerable<ResponseMedicalServices> GetAllMedicalServices()
        {
            var listMedicalServices = _medicalServiceRepository.GetAll();
            return _mapper.Map<IEnumerable<ResponseMedicalServices>>(listMedicalServices);
        }

        public IEnumerable<ResponseMedicalServices> GetAllMedicalServicesByDentistId(Guid requestDentistId)
        {

            var listMedicalServices = _medicalServiceRepository.GetAll().Where(x => x.Id == requestDentistId);
            return _mapper.Map<IEnumerable<ResponseMedicalServices>>(listMedicalServices);
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
