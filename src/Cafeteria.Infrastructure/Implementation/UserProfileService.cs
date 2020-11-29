using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Сafeteria.DataModels.Entities;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;
using Сafeteria.Infrastructure.ModelsDTO;
using Сafeteria.Services;
using Сafeteria.Services.Helpers;

namespace Сafeteria.Infrastructure.Implementation
{
    public class UserProfileService: IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly ILogger<UserProfileService> _logger;

        public UserProfileService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings, IMapper mapper, ILogger<UserProfileService> logger)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserProfileDTO> GetById(int profileId)
        {
            var profile = await _unitOfWork.UserProfileRepository.Get(profileId);

            if (profile == null)
            {
                _logger.LogError($"Couldn't get user profile from the database. ProfileId: {profileId}");
            }

            return _mapper.Map<UserProfileDTO>(profile);
        }

        public async Task<IEnumerable<UserProfileDTO>> GetAll()
        {
            var profiles = await _unitOfWork.UserProfileRepository.GetAll();

            if (profiles == null || !profiles.Any())
            {
                _logger.LogError("Couldn't find profiles in the database.");
            }

            return _mapper.Map<IEnumerable<UserProfileDTO>>(profiles);
        }

        public async Task<bool> DeleteById(int profileId)
        {
            try
            {
                var profile = await _unitOfWork.UserProfileRepository.Get(profileId);

                if (profile == null)
                {
                    _logger.LogError($"Couldn't get user profile from the database. ProfileId: {profileId}");
                    return false;
                }

                await _unitOfWork.UserProfileRepository.Remove(profile);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Couldn't delete profile from the database.");
                return false;
            }
        }

        public async Task<UserProfileDTO> Update(int profileId, UpdateUserCommand updateUserCommand)
        {
            UserProfile userProfile = await _unitOfWork.UserProfileRepository.Get(profileId);
            if (userProfile == null)
            {
                _logger.LogError($"Couldn't find profile in database. ProfileId: {profileId}");
                return null;
            }

            userProfile.FirstName = updateUserCommand.FirstName;
            userProfile.LastName = updateUserCommand.LastName;
            userProfile.DateOfBirth = updateUserCommand.DateOfBirth;

            await _unitOfWork.UserProfileRepository.Update(userProfile);
            await _unitOfWork.Save();

            return _mapper.Map<UserProfileDTO>(userProfile);
        }

        public async Task<UserProfileDTO> GetUserProfile(int userId)
        {
            var profile = await _unitOfWork.UserProfileRepository.GetUserProfile(userId);

            if (profile == null)
            {
                _logger.LogError($"Couldn't get profile from the database. UserId: {userId}");
            }

            return _mapper.Map<UserProfileDTO>(profile);
        }
    }
}
