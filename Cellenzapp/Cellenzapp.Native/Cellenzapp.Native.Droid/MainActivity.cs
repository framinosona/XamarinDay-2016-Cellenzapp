using System;
using System.Collections.Generic;
using System.Diagnostics;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Cellenzapp.Core;
using Cellenzapp.Core.Model;
using Cellenzapp.Core.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Square.Picasso;

namespace Cellenzapp.Native.Droid
{
	public class CellExpertViewHolder : RecyclerView.ViewHolder
	{
		public ImageView ExpertLargeImage { get; }
		public TextView ExpertFullName { get; }
		public TextView ExpertEmail { get; }

		public CellExpertViewHolder(View itemView) : base(itemView)
		{
			// Locate and cache view references:
			ExpertLargeImage = itemView.FindViewById<ImageView>(Resource.Id.expert_large_image);
			ExpertFullName = itemView.FindViewById<TextView>(Resource.Id.expert_full_name);
			ExpertEmail = itemView.FindViewById<TextView>(Resource.Id.expert_email);
		}
	}

	public class CellExpertAdapter : RecyclerView.Adapter
	{
		private List<ObservableExpert> _list;

		public CellExpertAdapter(IEnumerable<ObservableExpert> items)
		{
			_list = new List<ObservableExpert>(items);
		}

		public override int ItemCount => _list.Count;

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var h = (CellExpertViewHolder)holder;

			var dataContext = _list[position];

			if (dataContext.Picture != null)
			{
				Picasso.With(holder.ItemView.Context)
					   .Load(dataContext.Picture)
				       .Placeholder(Resource.Drawable.ic_expert_placeholder)
				       .CenterCrop()
				       .Fit()
					   .Into(h.ExpertLargeImage);
			}

			h.ExpertFullName.Text = dataContext.Name ?? string.Empty;
			h.ExpertEmail.Text = dataContext.Email ?? string.Empty;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_expert_item_layout, parent, false);

			var holder = new CellExpertViewHolder(view);

			return holder;
		}
	}

	[Activity(Label = "Cellenzapp.Native.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
		private CellExpertsViewModel _vm;
		private RecyclerView _recyclerView;
		private Cellenzapp.Native.Droid.ViewModel.ViewModelLocator _locator;

		public MainActivity()
		{
			_locator = new Cellenzapp.Native.Droid.ViewModel.ViewModelLocator();
		}

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			_vm = _locator.CellExpertsViewModel;
			Load();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			_recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
			_recyclerView.SetLayoutManager(new LinearLayoutManager(this));
        }

		private async void Load()
		{
			try
			{
				await _vm.Load();
				_recyclerView.SetAdapter(new CellExpertAdapter(_vm.CellExperts));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				if (Debugger.IsAttached)
					Debugger.Break();
			}
		}
    }
}


