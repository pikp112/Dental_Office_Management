using AutoMapper;
using WhiteDentalClinic.Application.Exceptions;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;
using WhiteDentalClinic.Shared.Services;
using ResponseUpdateDentistModel = WhiteDentalClinic.Application.Models.Dentist.ResponseUpdateDentistModel;

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
        public IEnumerable<ResponseDentistModel> GetAll()
        {
            var responseModelListDentists = _dentistRepository.GetAll();

            return _mapper.Map<IEnumerable<ResponseDentistModel>>(responseModelListDentists);

        }
        public ResponseDentistModel GetById(Guid id)
        {
            var dentistbyId = _dentistRepository.GetAll().FirstOrDefault(x => x.Id == id);

            return _mapper.Map<ResponseDentistModel>(dentistbyId);
        }

        public ResponseDentistModel Create(RequestCreateDentistModel requestDentistModel)
        {
            requestDentistModel.dentistServices.Add(new DentistServiceEntity
            {
                DentistId = requestDentistModel.Id,
                MedicalServiceId = Guid.Parse("3fbbb59a-d3fd-4400-9a03-0d95c34ce2b5")  // default "Medical consult"
            });

            var newDentist = _mapper.Map<Dentist>(requestDentistModel);

            this._dentistRepository.AddEntity(newDentist);

            return _mapper.Map<ResponseDentistModel>(newDentist);
        }

        public ResponseDentistModel DeleteDentist(Guid id)
        {
            var dentistbyId = _dentistRepository.GetAll().FirstOrDefault(x => x.Id == id);

            _dentistRepository.DeleteEntity(dentistbyId);

            return _mapper.Map<ResponseDentistModel>(dentistbyId);
        }


        public ResponseUpdateDentistModel Update(Guid id, RequestUpdateDentistModel updateDentistModel)
        {
            var selectedDentist = _dentistRepository.GetAll().FirstOrDefault(x => x.Id == id);

/*            var userDentistId = Guid.Parse("89336c8e-84b6-4bd2-8be0-3cf98ac96598");   //default only a single id. Check current dentist

            if (userDentistId != selectedDentist.Id)
            {
                throw new BadRequestException("You can update only your email.");
            }*/

            selectedDentist.Email = updateDentistModel.Email;

/*            selectedDentist.dentistServices.Add(new DentistServiceEntity
            {
                dentistId = id,
                medicalServiceId = updateDentistModel.addAnotherMedicalServiceId   
            });*/

            _dentistRepository.UpdateEntity(selectedDentist);
            _dentistServiceRepository.AddEntity(new DentistServiceEntity
            {
                Id = Guid.NewGuid(),
                MedicalServiceId = updateDentistModel.AdditionlMedicalServiceId,
                DentistId = id
            });

            return new ResponseUpdateDentistModel
            {
                Id = id
            };
        }
    }
}
