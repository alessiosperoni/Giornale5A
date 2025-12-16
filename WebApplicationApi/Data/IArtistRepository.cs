using SharedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplicationApi.Data
{
    public interface IArtistRepository
    {
        /// <summary>
        /// look for the artist with that id
        /// </summary>
        /// <param name="Id">id to find</param>
        /// <returns>Artist with ID from parameter</returns>
        Artist GetArtist(int Id);
        /// <summary>
        /// Create new Artist and save into repository
        /// </summary>
        /// <param name="Name"> Name of the artist</param>
        /// <returns>The new artist created</returns>
        Artist CreateArtist(string Name);

        /// <summary>
        /// List of all artists
        /// </summary>
        /// <returns>List of artists</returns>
        List<Artist> GetArtistsList();

    }
}
