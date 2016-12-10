using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ExpandableListViewDemo.Infrastructure;
using ExpandableListViewDemo.Models;
using Microsoft.Practices.ObjectBuilder2;

namespace ExpandableListViewDemo.ViewModels
{
    public class SelectCategory
    {
        public Category Category { get; set; }
        public bool Selected { get; set; }
    }

    public class MainPageViewModel : BindableBase
    {
        public ObservableCollection<Grouping<SelectCategory, Item>> Categories { get; set; } 

        public MainPageViewModel()
        {
            Categories = new ObservableCollection<Grouping<SelectCategory, Item>>();
            var selectCategories =
                Data.DataFactory.DataItems.Select(x => new SelectCategory {Category = x.Category, Selected = false})
                    .GroupBy(sc => new {sc.Category.CategoryId})
                    .Select(g => g.First())
                    .ToList();
            selectCategories.ForEach(sc => Categories.Add(new Grouping<SelectCategory, Item>(sc, new List<Item>())));
        }
    }
}
