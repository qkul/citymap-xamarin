using Android.Support.V7.Widget;
using Android.Views;
using CityMapXamarin.Models;
using FFImageLoading;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace CityMapXamarin.Android.Views.Cities
{
    public class CityAdapter : MvxRecyclerAdapter
    {       
        public ICommand CityClick { get; set; }

        public CityAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext?.LayoutInflaterHolder);           
            var itemView = itemBindingContext.BindingInflate(Resource.Layout.activity_city_item, parent, false);
            var viewHolder = new CityViewHolder(itemView,itemBindingContext);
            viewHolder.CityClicked += (s, e) =>
            {
                CityClick.Execute(s);
            };

            return viewHolder;
        }      
    }
}