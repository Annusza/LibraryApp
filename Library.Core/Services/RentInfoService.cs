using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services.Mappers;
using Library.Infrastructure.Logic;


namespace Library.Core.Services

{
    public class RentInfoService : IRentInfoService
    {
        private readonly IRentInfoRepository _iRentInfoRepository;

        public RentInfoService(IRentInfoRepository iIRentInfoRepository)
        {
            _iRentInfoRepository = iIRentInfoRepository;
        }

        public async Task<IEnumerable<RentInfoDto>> GetAll()
        {
            var rentInfos = await _iRentInfoRepository.GetAll();
            return rentInfos
                .Select(RentInfoMapper.MapRentInfoToRentInfoDto)
                .ToList();
        }

        public async Task<RentInfoDto> GetById(long id)
        {
            var rentInfo = await _iRentInfoRepository.GetById(id);
            return RentInfoMapper.MapRentInfoToRentInfoDto(rentInfo);
        }

        public async Task Add(RentInfoDto rentInfo)
        {
            
            await _iRentInfoRepository.Add(RentInfoMapper.MapRentInfoDtoToRentInfo(rentInfo));
        }

        public async Task Update(RentInfoDto entity)
        {
            await _iRentInfoRepository.Update(RentInfoMapper.MapRentInfoDtoToRentInfo(entity));
        }

        public async Task Delete(long id)
        {
            await _iRentInfoRepository.Delete(id);
        }
    }
}