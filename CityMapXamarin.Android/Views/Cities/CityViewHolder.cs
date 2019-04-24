using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading.Views;
using System;

namespace CityMapXamarin.Android.Views.Cities
{
    internal class CityViewHolder : RecyclerView.ViewHolder
    {
        public TextView TitleTextView { get; }
        public ImageViewAsync PhotoImageView { get; set; }

        public CityViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            TitleTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_city_title);
            PhotoImageView = itemView.FindViewById<ImageViewAsync>(Resource.Id.image_city_item);

            itemView.Click += (sender, e) => listener(LayoutPosition);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PhotoImageView?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}