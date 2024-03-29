﻿using AutoMapper;
using WhiteDentalClinic.Application.Exceptions;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
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
        private readonly IMedicalServiceRepository _medicalServiceRespository;
        public DentistService(
            IDentistRepository dentistRepository,
            IMapper mapper,
            IDentistServiceRepository dentistServiceRepository,
            IMedicalServiceRepository medicalServiceRepository,
            IClaimService claimService)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
            _claimService = claimService;
            _dentistServiceRepository = dentistServiceRepository;
            _medicalServiceRespository = medicalServiceRepository;
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
                MedicalServiceId = Guid.Parse("d83e231b-57e9-4460-9408-c23a06b0856d")  // default "Consult"
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
                MedicalServiceId = updateDentistModel.AdditionalMedicalServiceId,
                DentistId = id
            });

            return new ResponseUpdateDentistModel
            {
                Id = id
            };
        }


        public IEnumerable<ResponseMedicalServices> GetMedicalServicesByDentistId(Guid id)
        {
            List<Guid> listIdMedicalServices = new List<Guid>();
            foreach (var item in _dentistServiceRepository.GetAll())
            {
                if (item.DentistId == id)
                {
                    listIdMedicalServices.Add(item.MedicalServiceId);
                }
            }
            List<ResponseMedicalServices> allMedicalServicesByDentistId = new List<ResponseMedicalServices>();
            for (int i = 0; i <= listIdMedicalServices.Count; i++)
            {
                foreach (var medicalService in _medicalServiceRespository.GetAll())
                {
                    if (medicalService.Id == listIdMedicalServices.ElementAtOrDefault(i))
                    {
                        allMedicalServicesByDentistId.Add(new ResponseMedicalServices
                        {
                            Name = medicalService.Name,
                            Price = medicalService.Price,
                            Id = medicalService.Id
                        });
                    }
                }
            }
            return allMedicalServicesByDentistId;
        }
    }
}
