﻿using System;
using App_Code;

public partial class PageEditor : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PrepareFileUpload();
    }
}