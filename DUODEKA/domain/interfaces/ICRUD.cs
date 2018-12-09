using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.interfaces
{
    public interface ICRUD <T>
        //Create Read Update Delete.
        // 3x slash zorgt ervoor dat het stuk text als beschrijving van de functie wordt gegeven.
        //  Zorgt ervoor dat als een classe verwijderd wordt, de applicatie nogsteeds start
    {
        /// <summary>
        /// slaat een object op in het database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void create(T entity);

        /// <summary>
        /// haalt een object uit het database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T read(int id);

        /// <summary>
        /// haalt een object uit het database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T read(T entity);

        /// <summary>
        /// haalt alle objecten uit het database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<T> readAll();

        /// <summary>
        /// update een object
        /// </summary>
        /// <param name="entity"></param>
        void update(T entity);

        /// <summary>
        /// delete een object uit het database
        /// </summary>
        /// <param name="enity"></param>
        void delete(T enity);

        /// <summary>
        /// delete een object uit het database
        /// </summary>
        /// <param name="id"></param>
        void deleteById(int id);
    }
}
