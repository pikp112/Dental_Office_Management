using AutoMapper;
using WhiteDentalClinic.Application.Exceptions;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;
using WhiteDentalClinic.DataAccess.Entities.ServiceDentist;
using WhiteDentalClinic.DataAccess.Repositories.DentistRepository;
using WhiteDentalClinic.DataAccess.Repositories.DentistServiceRepository;
using WhiteDentalClinic.Shared.Services;
using UpdateDentistResponseModel = WhiteDentalClinic.Application.Models.Dentist.UpdateDentistResponseModel;

namespace WhiteDentalClinic.Application.Services
{
    public class DentistService : IDentistService
    {
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;
        private readonly IDentistRepository _dentistRepository;
        private readonly IDentistServiceRepository _dentistServiceRepository;
        public DentistService(
            IDentistRepository dentistRepository, 
            IMapper mapper,
            IDentistServiceRepository dentistServiceRepository,
            IClaimService claimService)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
            _claimService=claimService;
            _dentistServiceRepository = dentistServiceRepository;
        }
        public IEnumerable<DentistResponseModel> GetAllDentists()
        {
            var responseModelListDentists = _dentistRepository.GetAll();

            return _mapper.Map<IEnumerable<DentistResponseModel>>(responseModelListDentists);

        }
        public DentistResponseModel GetDentistById(Guid id)
        {
            var dentistbyId = _dentistRepository.GetAll().FirstOrDefault(x => x.Id == id);

            return _mapper.Map<DentistResponseModel>(dentistbyId);
        }

        public DentistResponseModel CreateDentist(CreateDentistRequestModel requestDentistModel)
        {
            requestDentistModel.dentistServices.Add(new DentistServiceEntity
            {
                dentistId = requestDentistModel.Id,
                medicalServiceId = Guid.Parse("3fbbb59a-d3fd-4400-9a03-0d95c34ce2b5")  // default "Medical consult"
            });

            var newDentist = _mapper.Map<Dentist>(requestDentistModel);

            this._dentistRepository.AddEntity(newDentist);

            return _mapper.Map<DentistResponseModel>(newDentist);
        }

        public DentistResponseModel DeleteDentist(Guid id)
        {
            var dentistbyId = _dentistRepository.GetAll().FirstOrDefault(x => x.Id == id);

            _dentistRepository.DeleteEntity(dentistbyId);

            return _mapper.Map<DentistResponseModel>(dentistbyId);
        }


        public UpdateDentistResponseModel UpdateDentist(Guid id, UpdateDentistRequestModel updateDentistModel)
        {
            var selectedDentist = _dentistRepository.GetAll().FirstOrDefault(x => x.Id == id);

            var userDentistId = Guid.Parse("89336c8e-84b6-4bd2-8be0-3cf98ac96598");   //default only a single id

            if (userDentistId != selectedDentist.Id)
            {
                throw new BadRequestException("You can update only your email.");
            }

            selectedDentist.Email = updateDentistModel.email;

            selectedDentist.dentistServices.Add(new DentistServiceEntity
            {
                dentistId = id,
                medicalServiceId = updateDentistModel.addAnotherMedicalServiceId   
            });

            _dentistRepository.UpdateEntity(selectedDentist);
            _dentistServiceRepository.AddEntity(new DentistServiceEntity
            {
                Id = Guid.NewGuid(),
                medicalServiceId = updateDentistModel.addAnotherMedicalServiceId,
                dentistId = id
            });

            return new UpdateDentistResponseModel
            {
                Id = id
            };
        }
    }
}
