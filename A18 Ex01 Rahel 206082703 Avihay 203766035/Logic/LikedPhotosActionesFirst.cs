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
    public class LikedPhotosActionesFirst : LikedPhotosActionesBase
    {
        public LikedPhotosActionesFirst(User i_LoggedUser)
            : base(i_LoggedUser)
        {
        }

        public override void FetchUserMostLikedPictures(PictureBox i_Pic1, PictureBox i_Pic2, PictureBox i_Pic3)
        {
            i_Pic1.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Key);
            i_Pic2.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Key);
            i_Pic3.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Key);

            UpdatePicBoxCurrUrl();
        }

        public override void ShowLikes(Label i_Pic1Likes, Label i_Pic2Likes, Label i_Pic3Likes, Label i_PicNumber1, Label i_PicNumber2, Label i_PicNumber3)
        {
            i_Pic1Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Value.ToString() + "Likes";
            i_Pic2Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Value.ToString() + "Likes";
            i_Pic3Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Value.ToString() + "Likes";
        }

        private void UpdatePicBoxCurrUrl()
        {
            m_currPicBox1PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Key;
            m_currPicBox2PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Key;
            m_currPicBox3PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Key;
        }
    } 
}