using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using static Android.Support.V7.Widget.RecyclerView;

namespace MinimalToDo.Utility
{
    public class RecyclerViewEmptySupport : RecyclerView
    {

        private View emptyView;

        private CustomAdapterDataObserver observer;

        public RecyclerViewEmptySupport(Context context) : base(context)
        {
        }

        public RecyclerViewEmptySupport(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public RecyclerViewEmptySupport(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        /// <summary>
        /// Sets the empty view.
        /// </summary>
        /// <param name="emptyView">Empty view.</param>
        public void SetEmptyView(View emptyView)
        {
            this.emptyView = emptyView;
        }

        /// <summary>
        /// Shows the empty view.
        /// </summary>
        public void ShowEmptyView()
        {
            var adapter = this.GetAdapter();

            if (adapter == null || emptyView == null) return;

            var isNoItem = adapter.ItemCount == 0;

            emptyView.Visibility = isNoItem ? ViewStates.Visible : ViewStates.Gone;
            this.Visibility = isNoItem ? ViewStates.Gone : ViewStates.Visible;
        }

        public override void SetAdapter(Adapter adapter)
        {
            base.SetAdapter(adapter);

            observer = new CustomAdapterDataObserver(ShowEmptyView);

            if (adapter == null) return;

            adapter.RegisterAdapterDataObserver(observer);
        }


        private class CustomAdapterDataObserver : AdapterDataObserver
        {
            private readonly Action action;

            public CustomAdapterDataObserver(Action action)
            {
                this.action = action;
            }

            public override void OnChanged()
            {
                base.OnChanged();
                action();
            }

            public override void OnItemRangeRemoved(int positionStart, int itemCount)
            {
                base.OnItemRangeRemoved(positionStart, itemCount);
                action();
            }

            public override void OnItemRangeInserted(int positionStart, int itemCount)
            {
                base.OnItemRangeInserted(positionStart, itemCount);
                action();
            }


        }
    }
}