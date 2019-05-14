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
        //private readonly IList<City> _cities = new List<City>();
        public ICommand CityClick { get; set; }
       // public event EventHandler<int> ItemClicked;

        public CityAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext?.LayoutInflaterHolder);
            // var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.activity_city_item, parent, false);
            var itemView = itemBindingContext.BindingInflate(Resource.Layout.activity_city_item, parent, false);
            var viewHolder = new CityViewHolder(itemView,itemBindingContext);
            viewHolder.CityClicked += (s, e) =>
            {
                CityClick.Execute(s);
            };

            return viewHolder;
        }

        //public override int ItemCount => _cities.Count;

        //public void Update(IEnumerable<City> cities)
        //{
        //    _cities.Clear();

        //    foreach (var city in cities)
        //    {
        //        _cities.Add(city);
        //    }
        //    NotifyDataSetChanged();
        //}

        //protected virtual void OnItemClicked(int position)
        //{
        //    ItemClicked?.Invoke(this, position);
        //}
    }
}