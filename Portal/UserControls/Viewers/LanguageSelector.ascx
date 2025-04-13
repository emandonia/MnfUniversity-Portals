<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageSelector.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.LanguageSelector" %>
<%@ Import Namespace="Common" %>

<div>
    <div style="width: 100%;">
        <div>

            <div style="border: 0 none; cursor: pointer;">
                <p class="style1">
                    

                    <a title="english" rel="nofollow" target="_self" href='<%= ResolveUrl(URLBuilder.FormURL("en", Page))%>'>
                        <img onmouseout="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/en_1.png';"
                            onmouseover="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/en.png';"
                            title="English" alt="english" src="<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/en_1.png"
                            width="25" height="25"/>English</a>

                    <a title="arabic" rel="nofollow" target="_self" href='<%= ResolveUrl( URLBuilder.FormURL("ar", Page))%>'>
    <img onmouseout="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ar_1.png';"
        onmouseover="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ar.png';"
        title="Arabic" alt="arabic" src="<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ar_1.png"
        width="25" height="25"/>العربية</a>

                    <a title="French" rel="nofollow" target="_self" href='<%= ResolveUrl(URLBuilder.FormURL("fr", Page))%>'>
                        <img onmouseout="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/fr.png';"
                            onmouseover="this.src='<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/fr.png';"
                            title="French" alt="French" src="<%=URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/fr_1.png" 
                            width="25" height="25"/>French</a>
                </p>
            </div>
        </div>
    </div>
</div>--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageSelector.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.LanguageSelector" %>
<%@ Import Namespace="Common" %>

<!-- Add custom styling for the dropdown -->
<style>
    /* Style the custom dropdown */
    .custom-dropdown {
        position: relative;
        display: inline-block;
        width: 110px;
        background-color: #f8f8f8;
        border: 1px solid #ccc;
        border-radius: 5px;
        cursor: pointer;
        padding: 10px;
        font-size: 16px;
    }

    /* Style the dropdown options container */
    .dropdown-options {
        display: none;
        position: absolute;
        top: 100%;
        left: 0;
        width: 100%;
        background-color: #fff;
        box-shadow: 0px 5px 10px rgba(0, 0, 0, 0.1);
        border-radius: 5px;
        z-index: 1000;
        max-height: 200px;
        overflow-y: auto;
    }

        .dropdown-options div {
            padding: 8px;
            display: flex;
            align-items: center;
            cursor: pointer;
        }

            .dropdown-options div:hover {
                background-color: #f0f0f0;
            }

        .dropdown-options img {
            margin-right: 10px;
            width: 20px;
            height: 20px;
        }

    /* Show the options when dropdown is clicked */
    .custom-dropdown.open .dropdown-options {
        display: block;
    }

    /* Style for selected language */
    .selected-language {
        display: flex;
        align-items: center;
    }

        .selected-language img {
            margin-right: 10px;
            width: 20px;
            height: 20px;
        }
</style>

<div>
    <div style="width: 100%;">
        <div>
            <div class="custom-dropdown" onclick="toggleDropdown()">
                <div class="selected-language">
                    <span id="selected-lang-text">
                        <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/lang.png" alt="اختر اللغة" />
                    </span>

                </div>

                <!-- Dropdown options -->
                <div class="dropdown-options">


                    <!-- Arabic -->
                    <div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("ar", Page)) %>', 'ar_1.png', 'العربية')">
                        <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ar_1.png" alt="Arabic" />
                        العربية
                    </div>
                    <!-- English -->
                    <div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("en", Page)) %>', 'en_1.png', 'English')">
                        <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/en_1.png" alt="English" />
                        English
                    </div>



                    <!-- French -->
                    <div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("fr", Page)) %>', 'fr_1.png', 'French')">
                        <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/fr_1.png" alt="French" />
                        French
                    </div>
                    <!-- Japan -->
                    <div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("ja", Page)) %>', 'Ja_1.png', 'Japanese')">
                        <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/Ja_1.png" alt="Japanese" />
                        Japanese
                    </div>
                    <!-- German -->
<div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("de-DE", Page)) %>', 'de_1.png', 'German')">
    <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/de_1.png" alt="German" />
    German
</div>
                    <!-- Turkish -->
<div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("tr", Page)) %>', 'tr.png', 'Turkish')">
    <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/tr.png" alt="Turkish" />
    Turkish
</div>

<!-- Persian -->
<div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("fa", Page)) %>', 'fa.png', 'Persian')">
    <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/fa.png" alt="Persian" />
    Persian
</div>

<!-- Chinese -->
<div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("zh-CN", Page)) %>', 'zh.png', 'Chinese')">
    <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/zh.png" alt="Chinese" />
    Chinese
</div>

<!-- Russian -->
<div onclick="changeLanguage('<%= ResolveUrl(URLBuilder.FormURL("ru", Page)) %>', 'ru.png', 'Russian')">
    <img src="<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/ru.png" alt="Russian" />
    Russian
</div>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    // Toggle the dropdown visibility
    function toggleDropdown() {
        document.querySelector('.custom-dropdown').classList.toggle('open');
    }

    // Change language and update UI
    function changeLanguage(url, imgName, langText) {
        window.location.href = url;
        document.getElementById('selected-lang-img').src = '<%= URLBuilder.VirtualPath(Page) %>/Styles/Main/images/lang/' + imgName;
        document.getElementById('selected-lang-text').innerText = langText;
        document.querySelector('.custom-dropdown').classList.remove('open');
    }
</script>
