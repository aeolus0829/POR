﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connDB;

namespace POR
{
    public partial class Form1 : Form
    {
        string winFormVersion, formName;
        bool TESTING, isActive;

        public Form1()
        {
            //開發資訊
            formName = "POR";
            TESTING = true;
            winFormVersion = "1.00";

            chkFormStatusClass chkForm = new chkFormStatusClass();

            isActive = chkForm.isFormActive(formName);

            if (isActive) InitializeComponent();
            else MessageBox.Show("目前程式停用中，請連絡資訊組");

        }
    }
}
