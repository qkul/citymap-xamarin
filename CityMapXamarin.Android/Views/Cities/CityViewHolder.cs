using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading.Views;
using System;
using CityMapXamarin.Android.Resources;
using CityMapXamarin.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace CityMapXamarin.Android.Views.Cities
{
    internal class CityViewHolder : MvxRecyclerViewHolder
    {
        private TextView _titleTextView { get; set; }
        private ImageViewAsync _photoImageView { get; set; }
        private LinearLayout _linearLayout { get; set; } 
        public event EventHandler CityClicked;

        public CityViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
           InitComponents(itemView);
           AppBindings();
        }
        private void AppBindings()
        {
            var bindingSet = this.CreateBindingSet<CityViewHolder, City>();
            bindingSet.Bind(_titleTextView)
                .For(p => p.Text)
                .To(vm => vm.Title);
            bindingSet.Bind(_photoImageView)
                .For(p => p.Drawable)
                .To(m => m.Url).WithConversion<ImagePathToDrawableConverter>();

            bindingSet.Apply();
        }

        private void InitComponents(View itemView)
        {
            _titleTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_city_title);
            _photoImageView = itemView.FindViewById<ImageViewAsync>(Resource.Id.image_city_item);
            _linearLayout = itemView.FindViewById<LinearLayout>(Resource.Id.cityItemCell);

            _linearLayout.Click += (s, e) =>
            {
                CityClicked(DataContext as City, null);
            };       
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _photoImageView?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}