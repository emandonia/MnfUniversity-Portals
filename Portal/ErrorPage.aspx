<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="MnfUniversity_Portals.ErrorPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Error - Something Went Wrong</title>
    <style>
        /* General page setup */
        body {
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f7f7f7;
            color: #333;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            text-align: center;
        }

        /* Container for the error page */
        .error-container {
            background-color: #ffffff;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
            border-radius: 12px;
            padding: 40px;
            max-width: 900px;
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }

        /* Error image */
        .error-image img {
            max-width: 400px; /* Increased image size */
            width: 100%;
            height: auto;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            margin-bottom: 30px; /* Space between image and text */
        }

        /* Error message section */
        .error-message h1 {
            font-size: 48px;
            color: #e74c3c;
            margin-bottom: 20px;
        }

        .error-message p {
            font-size: 20px;
            color: #555;
            margin-bottom: 30px;
            line-height: 1.6;
        }

        /* Action buttons */
        .error-actions {
            margin-top: 20px;
            display: flex;
            justify-content: center;
            gap: 15px;
        }

        .error-actions .btn {
            background-color: #3498db;
            color: #fff;
            padding: 12px 25px;
            border-radius: 8px;
            font-size: 16px;
            text-decoration: none;
            transition: background-color 0.3s ease;
        }

        .error-actions .btn:hover {
            background-color: #2980b9;
        }

        /* Mobile responsiveness */
        @media (max-width: 768px) {
            .error-container {
                padding: 20px;
            }

            .error-message h1 {
                font-size: 36px;
            }

            .error-message p {
                font-size: 18px;
            }

            .error-actions {
                flex-direction: column;
                gap: 10px;
            }
        }
    </style>
</head>
<body>
    <div class="error-container">
        <div class="error-image">
            <img src="error.jpg" alt="Error Illustration"> <!-- Image placed above text -->
        </div>
        <div class="error-message">
            <h1>Oops! Something Went Wrong</h1>
            <p>We are sorry for the inconvenience. Our team has been notified and is working to fix the issue. Please try again later, or feel free to contact support.</p>
            <div class="error-actions">
                <a href="/" class="btn">Go to Home</a>
                
            </div>
        </div>
    </div>
</body>
</html>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="MnfUniversity_Portals.ErrorPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Error - Something Went Wrong</title>
    <style>
        /* General page setup */
        body {
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f7f7f7;
            color: #333;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            text-align: center;
        }

        /* Container for the error page */
        .error-container {
            background-color: #ffffff;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
            border-radius: 12px;
            padding: 40px;
            max-width: 900px;
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }

        /* Error message section */
        .error-message h1 {
            font-size: 48px;
            color: #e74c3c;
            margin-bottom: 20px;
        }

        .error-message p {
            font-size: 20px;
            color: #555;
            margin-bottom: 30px;
            line-height: 1.6;
        }

        /* Action buttons */
        .error-actions {
            margin-top: 20px;
            display: flex;
            justify-content: center;
            gap: 15px;
        }

        .error-actions .btn {
            background-color: #3498db;
            color: #fff;
            padding: 12px 25px;
            border-radius: 8px;
            font-size: 16px;
            text-decoration: none;
            transition: background-color 0.3s ease;
        }

        .error-actions .btn:hover {
            background-color: #2980b9;
        }

        /* Error Image */
        .error-image img {
            max-width: 250px;
            border-radius: 8px;
            margin-top: 30px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }

        /* Mobile responsiveness */
        @media (max-width: 768px) {
            .error-container {
                padding: 20px;
            }

            .error-message h1 {
                font-size: 36px;
            }

            .error-message p {
                font-size: 18px;
            }

            .error-actions {
                flex-direction: column;
                gap: 10px;
            }
        }
    </style>
</head>
<body>
    <div class="error-container">
        <div class="error-message">
            <h1>Oops! Something Went Wrong</h1>
            <p>We are sorry for the inconvenience. Our team has been notified and is working to fix the issue. Please try again later, or feel free to contact support.</p>
            <div class="error-actions">
                <a href="/" class="btn">Go to Home</a>
                 
            </div>
        </div>
        <div class="error-image">
            <img src="error.jpg" alt="Error Illustration">
        </div>
    </div>
</body>
</html>--%>
 
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="MnfUniversity_Portals.ErrorPage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Error - Something Went Wrong</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            color: #333;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .error-container {
            background-color: #ffffff;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            display: flex;
            padding: 40px;
            max-width: 1000px;
            width: 100%;
            flex-direction: row;
            justify-content: space-between;
            align-items: center;
        }

        .error-message {
            flex: 1;
            padding: 20px;
        }

        .error-message h1 {
            font-size: 36px;
            color: #e74c3c;
            margin-bottom: 10px;
        }

        .error-message p {
            font-size: 18px;
            color: #555;
            margin-bottom: 20px;
        }

        .error-actions .btn {
            background-color: #3498db;
            color: #fff;
            padding: 12px 20px;
            border-radius: 5px;
            text-decoration: none;
            font-size: 16px;
            margin-right: 10px;
            transition: background-color 0.3s ease;
        }

        .error-actions .btn:hover {
            background-color: #2980b9;
        }

        .error-image img {
            max-width: 250px;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }
    </style>
</head>
<body>
    <div class="error-container">
        <div class="error-message">
            <h1>Oops! Something went wrong</h1>
            <p>We apologize for the inconvenience. Please try again later or contact support.</p>
            <div class="error-actions"> 
              </div>
        </div>
       
    </div>
</body>--%>
</html>
