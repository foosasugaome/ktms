<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="myprofile.aspx.cs" Inherits="ktms.myprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>User Profile</h1>
            <ul>
                <li><a href="">Pages</a></li>
                <li>User Profile</li>
            </ul>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="card user-profile o-hidden mb-4">
            <div class="header-cover" style="background-image: url('assets/images/photo-wide-3.jpg')"></div>
            <div class="user-info">
                <asp:Image ID="imgUserPicture" AlternateText="" CssClass="profile-picture avatar-lg mb-2" runat="server" />
                
                <p class="m-0 text-24"><asp:Label ID="lblFullName" Text="" runat="server" /></p>
            </div>
            <div class="card-body">

                <div class="tab-content" id="profileTabContent">
                    <div id="about" role="tabpanel" aria-labelledby="about-tab">
                        <h4>Personal Information</h4>
                        <hr>
                        <div class="row">

                            <div class="col-md-6 col-6">
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-Calendar text-16 mr-1"></i>First Name</p>
                                    <span><asp:Label ID="lblFirstName" Text="" runat="server" /></span>
                                </div>
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-Edit-Map text-16 mr-1"></i>Last name</p>
                                    <span><asp:Label ID="lblLastName" Text="" runat="server" /></span>
                                </div>
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-Globe text-16 mr-1"></i>Email</p>
                                    <span><asp:Label ID="lblEmail" Text="" runat="server" /></span>
                                </div>
                            </div>

                            <div class="col-md-6 col-6">
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-MaleFemale text-16 mr-1"></i>Phone</p>
                                    <span><asp:Label ID="lblPhone" Text="" runat="server" /></span>
                                </div>
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-MaleFemale text-16 mr-1"></i>User Type</p>
                                    <span><asp:Label ID="lblUserType" Text="" runat="server" /></span>
                                </div>
                               <%-- <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-Cloud-Weather text-16 mr-1"></i>Website</p>
                                    <span>www.ui-lib.com</span>
                                </div>--%>
                            </div>
                            
                            <%--<div class="col-md-4 col-6">
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-Face-Style-4 text-16 mr-1"></i> Email</p>
                                    <span>norman@gmail.com</span>
                                </div>
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-Professor text-16 mr-1"></i>Experience</p>
                                    <span>8 Years</span>
                                </div>
                                <div class="mb-4">
                                    <p class="text-primary mb-1"><i class="i-Home1 text-16 mr-1"></i>School</p>
                                    <span>School of Digital Marketing</span>
                                </div>
                            </div>--%>

                        </div>
                        <hr>
                        <%--<h4>Other Info</h4>
                            <p class="mb-4">Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsum dolore labore reiciendis ab quo ducimus reprehenderit natus debitis, provident ad iure sed aut animi dolor incidunt voluptatem. Blanditiis, nobis aut.</p>
                            <div class="row">
                                <div class="col-md-2 col-sm-4 col-6 text-center">
                                    <i class="i-Plane text-32 text-primary"></i>
                                    <p class="text-16 mt-1">Travelling</p>
                                </div>
                                <div class="col-md-2 col-sm-4 col-6 text-center">
                                    <i class="i-Camera text-32 text-primary"></i>
                                    <p class="text-16 mt-1">Photography</p>
                                </div>
                                <div class="col-md-2 col-sm-4 col-6 text-center">
                                    <i class="i-Car-3 text-32 text-primary"></i>
                                    <p class="text-16 mt-1">Driving</p>
                                </div>
                                <div class="col-md-2 col-sm-4 col-6 text-center">
                                    <i class="i-Gamepad-2 text-32 text-primary"></i>
                                    <p class="text-16 mt-1">Gaming</p>
                                </div>
                                <div class="col-md-2 col-sm-4 col-6 text-center">
                                    <i class="i-Music-Note-2 text-32 text-primary"></i>
                                    <p class="text-16 mt-1">Music</p>
                                </div>
                                <div class="col-md-2 col-sm-4 col-6 text-center">
                                    <i class="i-Shopping-Bag text-32 text-primary"></i>
                                    <p class="text-16 mt-1">Shopping</p>
                                </div>
                            </div>--%>
                    </div>

                </div>

            </div>
        </div>


    </div>

</asp:Content>
