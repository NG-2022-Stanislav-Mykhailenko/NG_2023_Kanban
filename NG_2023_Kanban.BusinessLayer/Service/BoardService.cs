﻿using AutoMapper;
using NG_2023_Kanban.BusinessLayer.Interfaces;
using NG_2023_Kanban.BusinessLayer.Models;
using NG_2023_Kanban.DataLayer.Repositories;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;

namespace NG_2023_Kanban.BusinessLayer.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardService(IBoardRepository boardRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }

        public async Task<BoardModel> GetAsync(int id)
        {
            return _mapper.Map<BoardModel>(await _boardRepository.GetAsync(id));
        }

        public async Task<ICollection<BoardModel>> GetAllAsync()
        {
            return _mapper.Map<ICollection<BoardModel>>(await _boardRepository.GetAllAsync());
        }
    }
}
