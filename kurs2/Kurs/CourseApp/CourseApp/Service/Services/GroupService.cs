using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _GroupRepository;
        private int _count;

        public GroupService()
        {
            _GroupRepository = new GroupRepository();
        }
        public Group Create(Group group)
        {
            group.Id = _count;
            _GroupRepository.Create(group);
            _count++;
            return group;

        }

        public void Delete(int id)
        {
            Group group = GetById(id);
            _GroupRepository.Delete(group);
        }

        public List<Group> GetAll()
        {
            return _GroupRepository.GetAll();
        }

        public Group GetById(int id)
        {
            var group = _GroupRepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group; 
            
        }

        public List<Group> Search(string search)
        {
            return _GroupRepositroy.GetAll(m => m.Name.Trim().ToLower().StartsWith(search.Trim().ToLower()));
        }

        public Group Update(int id, Group group)
        {
            Group dbGroup = GetById(id);
            if (dbGroup is null) return null;
            group.Id = dbGroup.Id;
            _GroupRepository.Update(group);
            return dbGroup;
        }
    }
}
