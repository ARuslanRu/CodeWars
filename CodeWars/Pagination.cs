using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    /// <summary>
    /// Pagination is about dividing up results into pages with a fixed number of items on each page, your task is to write a generic pagination class that manages pagination for any class implementing IEnumerable<T>
    /// The class should take in the IEnumerable<T> to manage in the constructor and must have the following properties:
    /// IEnumerable<T> Items // gets the items for the current page index
    /// int CurrentPage      // gets/sets the current page index, starting at 1
    /// int ItemsPerPage     // gets/sets the number of items to return on each page, default 10 items
    /// int Total            // gets the total number of items in the source
    /// int TotalPages       // gets total number of pages
    /// If CurrentPage is set to <= 0 it should default back to page 1.
    /// If CurrentPage is set to > TotalPages Items should be empty (not null).
    /// If ItemsPerPage is set to <= 0 it should default back to 10 items.
    /// Properties listed as only gettable should not be settable.
    /// Settable properties can be set in any order.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pagination<T>
    {
        IEnumerable<T> _source;
        int _currentPage = 1;
        int _itemsPerPage = 10;

        // gets the items for the current page index
        public IEnumerable<T> Items
        {
            get
            {
                return _source.Skip((CurrentPage - 1) * ItemsPerPage).Take(ItemsPerPage);
            }
        }

        // gets/sets the current page index, starting at 1
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value <= 0 ? 1 : value;
            }
        }

        // gets/sets the number of items to return on each page, default 10 items
        public int ItemsPerPage 
        {
            get
            {
                return _itemsPerPage;
            }
            set
            {
                _itemsPerPage = value <= 0 ? 10 : value;
            }
        }

        // gets the total number of items in the source
        public int Total { get; }
        
        // gets total number of pages
        public int TotalPages 
        {
            get
            {
                return (int)Math.Ceiling((decimal)Total / ItemsPerPage);
            }
        }
        public Pagination(IEnumerable<T> source)
        {
            _source = source;
            Total = source.Count();
        }
    }
}
