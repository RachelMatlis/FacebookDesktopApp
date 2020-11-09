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
    /// Template Method abstract class
    /// Implemt actiones on liked phothos feature 2 
    /// </summary>
    public abstract class LikedPhotosActionesBase : LikedPhotos
    {
        protected string m_currPicBox1PicUrl = null;
        protected string m_currPicBox2PicUrl = null;
        protected string m_currPicBox3PicUrl = null;

        public LikedPhotosActionesBase(User i_LoggedUser)
            : base(i_LoggedUser)
        {
        }
        
        public abstract void FetchUserMostLikedPictures(PictureBox i_Pic1, PictureBox i_Pic2, PictureBox i_Pic3);

        public abstract void ShowLikes(Label i_Pic1Likes, Label i_Pic2Likes, Label i_Pic3Likes, Label i_PicNumber1, Label i_PicNumber2, Label i_PicNumber3);

        public void ChangePicInPicBox1(PictureBox i_PicBox, Label i_PicNumber, Label i_LikesAmount)
        {
            if (m_currPicBox1PicUrl != null)
            {
                if (m_currPicBox1PicUrl == PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Key)
                {
                    i_PicBox.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 4].Key);
                    i_LikesAmount.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 4].Value.ToString() + " Likes !";
                    i_PicNumber.Text = "4";
                    m_currPicBox1PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 4].Key;
                }
                else
                {
                    i_PicBox.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Key);
                    i_LikesAmount.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Value.ToString() + " Likes !";
                    i_PicNumber.Text = "1";
                    m_currPicBox1PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 1].Key;
                }
            }
        }

        public void ChangePicInPicBox2(PictureBox i_PicBox, Label i_PicNumber, Label i_LikesAmount)
        {
            if (m_currPicBox2PicUrl != null)
            {
                if (m_currPicBox2PicUrl == PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Key)
                {
                    i_PicBox.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 5].Key);
                    i_LikesAmount.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 5].Value.ToString() + " Likes !";
                    i_PicNumber.Text = "5";
                    m_currPicBox2PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 5].Key;
                }
                else
                {
                    i_PicBox.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Key);
                    i_LikesAmount.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Value.ToString() + " Likes !";
                    i_PicNumber.Text = "2";
                    m_currPicBox2PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 2].Key;
                }
            }
        }

        public void ChangePicInPicBox3(PictureBox i_PicBox, Label i_PicNumber, Label i_LikesAmount)
        {
            if (m_currPicBox3PicUrl != null)
            {
                if (m_currPicBox3PicUrl == PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Key)
                {
                    i_PicBox.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 6].Key);
                    i_LikesAmount.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 6].Value.ToString() + " Likes !";
                    i_PicNumber.Text = "6";
                    m_currPicBox3PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 6].Key;
                }
                else
                {
                    i_PicBox.Load(PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Key);
                    i_LikesAmount.Text = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Value.ToString() + " Likes !";
                    i_PicNumber.Text = "3";
                    m_currPicBox3PicUrl = PhotosAndLikesByValueOrder[SizeOfPhotosAndLikesByValueOrder - 3].Key;
                }
            }
        }

        public void SaveCurrPicBoxPicsUrl(string i_Pic1Url, string i_Pic2Url, string i_Pic3Url)
        {
            m_currPicBox1PicUrl = i_Pic1Url;
            m_currPicBox2PicUrl = i_Pic2Url;
            m_currPicBox3PicUrl = i_Pic3Url;
        }
    }
}
