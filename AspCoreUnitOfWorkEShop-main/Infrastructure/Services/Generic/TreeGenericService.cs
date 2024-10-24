using Infrastructure.Database;
using Domain.Enum;
using Application.ViewModels;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public static class TreeGenericService<T>
    {
        //public static List<T> GetChildren(List<T> foos, int id)
        //{
        //    return foos
        //        .Where(x => x.ParentId == id)
        //        .Union(foos.Where(x => x.ParentId == id)
        //            .SelectMany(y => GetChildren(foos, y.Id))
        //        ).ToList();
        //}
    }
}
