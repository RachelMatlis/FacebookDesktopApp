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
    public class LikedPhotosActionesChanged : LikedPhotosActionesBase
    {
        public LikedPhotosActionesChanged(User i_LoggedUser)
            : base(i_LoggedUser)
        {
        }

        public override void FetchUserMostLikedPictures(PictureBox i_Pic1, PictureBox i_Pic2, PictureBox i_Pic3)
        {
          i_Pic1.Load(m_currPicBox1PicUrl);
          i_Pic2.Load(m_currPicBox2PicUrl);
          i_Pic3.Load(m_currPicBox3PicUrl);
        }

        public override void ShowLikes(Label i_Pic1Likes, Label i_Pic2Likes, Label i_Pic3Likes, Label i_PicNumber1, Label i_PicNumber2, Label i_PicNumber3)
        {
            if (m_currPicBox1PicUrl == PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Key)
            {
                i_Pic1Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Value.ToString() + "Likes";
            }
            else
            {
                i_Pic1Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 4].Value.ToString() + "Likes";
                i_PicNumber1.Text = "4";
            }

            if (m_currPicBox2PicUrl == PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Key)
            {
                i_Pic2Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Value.ToString() + "Likes";
            }
            else
            {
                i_Pic2Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 5].Value.ToString() + "Likes";
                i_PicNumber2.Text = "5";
            }

            if (m_currPicBox2PicUrl == PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Key)
            {
                i_Pic3Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Value.ToString() + "Likes";
            }
            else
            {
                i_Pic3Likes.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 6].Value.ToString() + "Likes";
                i_PicNumber3.Text = "6";
            }
        }
    }   
}