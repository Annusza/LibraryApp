using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Contract.BookDto;
using Library.Core.Services.Mappers;
using Library.Infrastructure;
using Library.Infrastructure.Logic;
using Library.Infrastructure.Model;


namespace Library.Core.Services

{
    public class RentInfoService : IRentInfoService
    {
        private readonly IRentInfoRepository _iRentInfoRepository;
        private readonly IBookRepository _ibookRepository;
        private readonly IUserRepository _iUserRepository;


        public RentInfoService(IRentInfoRepository iIRentInfoRepository, IBookRepository iBookRepository,
            IUserRepository iUserRepository
        )
        {
            _iRentInfoRepository = iIRentInfoRepository;
            _ibookRepository = iBookRepository;
            _iUserRepository = iUserRepository;
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

        public async Task Add(RentInfoDto dto)
        {
            RentInfo entity = RentInfoMapper.MapRentInfoDtoToRentInfo(dto);

            entity.RentedBook = await _ibookRepository.GetById(dto.RentedBookId.GetValueOrDefault());
            entity.BorrowingUser = await _iUserRepository.GetById(dto.BorrowingUserId.GetValueOrDefault());
            await _iRentInfoRepository.Add(entity);
        }

        public async Task Update(RentInfoDto dto)
        {
            RentInfo entity = RentInfoMapper.MapRentInfoDtoToRentInfo(dto);

            entity.RentedBook = await _ibookRepository.GetById(dto.RentedBookId.GetValueOrDefault());
            entity.BorrowingUser = await _iUserRepository.GetById(dto.BorrowingUserId.GetValueOrDefault());

            await _iRentInfoRepository.Update(entity);
        }

        public async Task Delete(long id)
        {
            await _iRentInfoRepository.Delete(id);
        }
    }
}