using Application.Contracts;
using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;
using System;

namespace Infrastructure.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        private readonly IMapper _mapper;
        public LocationRepository(DatabaseContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IEnumerable<LocationVm> ListModel(IEnumerable<Location> listSelected, LocationReadVm search = null)
        {
            //search

            if (search != null)
            {
                //if (!string.IsNullOrWhiteSpace(search.Title))
                //{
                //    listSelected = listSelected.Where(s => s.Title == search.Title);
                //}
            }

            List<LocationVm> model = new List<LocationVm>();

            foreach (var item in listSelected.Where(s=>s.IsEnable==true))
            {
                LocationVm modelItem = new LocationVm();

                modelItem.Id = item.Id;
                modelItem.ParentId = item.ParentId==null?null: item.ParentId;
                modelItem.Name = item.Name;
                modelItem.Code = item.Code;
                modelItem.NO = item.NO;
                modelItem.DateRegister = item.DateRegister;
                modelItem.Description = item.Description;
                modelItem.CreatorUserId = item.CreatorUserId;
                modelItem.Status = item.Status;
                modelItem.StatusEn =((LocationStatusEnum)item.Status).ToString();
                modelItem.StatusStr =Infrastructure.Utils.EnumUtils.GetDescription(item.Status);
                modelItem.Type = item.Type;

                model.Add(modelItem);
            }

            return model;
        }
    }
}
