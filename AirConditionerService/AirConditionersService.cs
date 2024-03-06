using AirConditionerBussinessObjects.Models;
using AirConditionerDAO.PhotoUpload.Interface;
using AirConditionerRepository;
using AirConditionerRepository.Interface;
using AirConditionerService.Interface;
using AirConditionerService.ViewModel;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerService
{
    public class AirConditionersService : IAirConditionerService
    {
        private readonly IAirConditionerRepo airConditionerRepo = null;
        private readonly IPhotoService _photoService;
        public AirConditionersService(IPhotoService photoService)
        {
            airConditionerRepo = new AirConditionerRepo();
            _photoService = photoService;
        }

        public async Task<bool> AddAirConditioner(AddAirConditionerViewModel airConditionerVM)
        {
            var result = await _photoService.AddPhotoAsync(airConditionerVM.Image);
            if (result != null)
            {
                var airConditioner = new AirConditioner
                {
                    AirConditionerName = airConditionerVM.AirConditionerName,
                    Warranty = airConditionerVM.Warranty,
                    SoundPressureLevel = airConditionerVM.SoundPressureLevel,
                    Image = result.Url.ToString(),
                    FeatureFunction = airConditionerVM.FeatureFunction,
                    Quantity = airConditionerVM.Quantity,
                    DollarPrice = airConditionerVM.DollarPrice,
                    SupplierId = airConditionerVM.SupplierId
                };

                return await airConditionerRepo.AddAirConditioner(airConditioner);
            }
            else
            {
                return false;
            }

            
        }

        public bool DeleteAirConditioner(int id)
        {
            return airConditionerRepo.DeleteAirConditioner(id);
        }

        public async Task<bool> EditAirConditioner(int id, EditAirConditionerViewModel airConditionerVM)
        {
            var existingAirConditioner = await airConditionerRepo.GetAirConditionerByIdAsync(id);
            if (existingAirConditioner != null)
            {
                try
                {
                    // Xóa ảnh cũ
                    if (!string.IsNullOrEmpty(existingAirConditioner.Image))
                    {
                        await _photoService.DeletePhotoAsync(existingAirConditioner.Image);
                    }

                    // Tạo ảnh mới
                    string? newImageUrl = existingAirConditioner.Image; // Mặc định là ảnh cũ

                    if (airConditionerVM.Image != null)
                    {
                        var photoResult = await _photoService.AddPhotoAsync(airConditionerVM.Image);
                        newImageUrl = photoResult.Url.ToString(); // Sử dụng URL của ảnh mới
                    }

                    // Cập nhật thông tin cho existingAirConditioner
                    existingAirConditioner.AirConditionerName = airConditionerVM.AirConditionerName;
                    existingAirConditioner.Warranty = airConditionerVM.Warranty;
                    existingAirConditioner.SoundPressureLevel = airConditionerVM.SoundPressureLevel;
                    existingAirConditioner.Image = newImageUrl;
                    existingAirConditioner.FeatureFunction = airConditionerVM.FeatureFunction;
                    existingAirConditioner.Quantity = airConditionerVM.Quantity;
                    existingAirConditioner.DollarPrice = airConditionerVM.DollarPrice;
                    existingAirConditioner.SupplierId = airConditionerVM.SupplierId;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    return await airConditionerRepo.EditAirConditioner(id, existingAirConditioner);
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có
                    // ...
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public AirConditioner GetAirConditionerById(int id)
        {
            return airConditionerRepo.GetAirConditionerById(id);
        }
        public Task<AirConditioner> GetAirConditionerByIdAsync(int id)
        {
            return airConditionerRepo.GetAirConditionerByIdAsync(id);
        }
        public Task<AirConditioner> GetAirConditionerByIdNoTracking(int id)
        {
            return airConditionerRepo.GetAirConditionerByIdNoTracking(id);
        }

        public List<AirConditioner> GetAirConditionersByName(string name)
        {
            return airConditionerRepo.GetAirConditionersByName(name);
        }

        public List<AirConditioner> GetAllAirConditioners()
        {
            return airConditionerRepo.GetAllAirConditioners();
        }

        public IEnumerable<SupplierCompany> GetSupplierCompanies()
        {
            return airConditionerRepo.GetSupplierCompanies();
        }
        public List<AirConditioner> SearchByName(string name)
        {
            return airConditionerRepo.SearchByName(name);
        }
    }
}
