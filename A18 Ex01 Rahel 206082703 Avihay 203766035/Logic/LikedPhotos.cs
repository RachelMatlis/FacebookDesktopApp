using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using A18_Ex01_Rahel_206082703_Avihay_203766035.Logic;
using FacebookWrapper;
using Facebook;
using FacebookWrapper.ObjectModel;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.Logic
{
    /// <summary>
    /// This class create a dictionary of Photos and likes. and sort it by likes amount.
    /// Key = photo url, Value= photo likes amount.
    /// </summary>
    public class LikedPhotos
    {
        private User m_User;

        protected List<KeyValuePair<string, int>> PhotosAndLikesByValueOrder { get; private set; }

        public int SizeOfPhotosAndLikesByValueOrder { get; private set; }

        public LikedPhotos(User i_LoggedUser)
        {
            m_User = i_LoggedUser;
            createDictOfUserPicturesSoretedByLikes();
        }

        private void createDictOfUserPicturesSoretedByLikes()
        {
            Dictionary<string, int> photosAndLikes = new Dictionary<string, int>();

            if (m_User.Albums != null)
            {
                foreach (Album album in m_User.Albums)
                {
                    if (album.Photos != null)
                    {
                        foreach (Photo photo in album.Photos)
                        {
                            photosAndLikes.Add(photo.PictureNormalURL, photo.LikedBy.Count);
                        }
                    }
                }
            }

            PhotosAndLikesByValueOrder = (from kv in photosAndLikes orderby kv.Value select kv).ToList();
            SizeOfPhotosAndLikesByValueOrder = PhotosAndLikesByValueOrder.Count;
        }
    }
}