<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ktms.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div id="activePage" hidden>dashboard</div>
        <div class="breadcrumb">
            <h1 class="mr-2">Dashboard</h1>

        </div>
        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-lg-6 col-md-12">
                <!-- CARD ICON -->
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <div class="card card-icon mb-4">
                            <div class="card-body text-center">
                                <i class="i-Data-Upload"></i>
                                <p class="text-muted mt-2 mb-2">Total Students</p>
                                <p class="text-primary text-24 line-height-1 m-0">
                                    <asp:Label ID="lblTotalStudents" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <div class="card card-icon mb-4">
                            <div class="card-body text-center">
                                <i class="i-Add-User"></i>
                                <p class="text-muted mt-2 mb-2">New Students</p>
                                <p class="text-primary text-24 line-height-1 m-0">
                                    <asp:Label ID="lblNewStudents" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <div class="card card-icon mb-4">
                            <div class="card-body text-center">
                                <i class="i-Money-2"></i>
                                <p class="text-muted mt-2 mb-2">Test Types</p>
                                <p class="text-primary text-24 line-height-1 m-0">
                                    <asp:Label ID="lblTestType" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>


                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <div class="card card-icon mb-4">
                            <div class="card-body text-center">
                                <i class="i-Data-Upload"></i>
                                <p class="text-muted mt-2 mb-2">Total Attempts</p>
                                <p class="text-primary text-24 line-height-1 m-0">
                                    <asp:Label ID="lblTotalAttempts" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <div class="card card-icon mb-4">
                            <div class="card-body text-center">
                                <i class="i-Add-User"></i>
                                <p class="text-muted mt-2 mb-2">Passed Attempts</p>
                                <p class="text-primary text-24 line-height-1 m-0">
                                    <asp:Label ID="lblPassedAttempts" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-sm-6">
                        <div class="card card-icon mb-4">
                            <div class="card-body text-center">
                                <i class="i-Money-2"></i>
                                <p class="text-muted mt-2 mb-2">Failed Attempts</p>
                                <p class="text-primary text-24 line-height-1 m-0">
                                    <asp:Label ID="lblFailedAttempts" runat="server" />
                                </p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-lg-6 col-md-12">
                <div class="card mb-4">
                    <div class="card-body p-0">
                        <h5 class="card-title m-0 p-3">Students Test</h5>
                        <div id="echart4" style="height: 300px"></div>
                    </div>
                </div>
            </div>


        </div>

        <div class="row">
            <div class="col-lg-8 col-md-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="card-title">Student Report</div>
                        <div id="echartBar" style="height: 300px;"></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-sm-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="card-title">Test Types</div>
                        <div id="echartPie" style="height: 300px;"></div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script src="assets/js/vendor/echarts.min.js"></script>
    <script src="assets/js/es5/echart.options.js"></script>
    <script src="assets/js/es5/dashboard.v1.script.js"></script>
    <script src="assets/js/vendor/datatables.min.js"></script>
    <script src="assets/js/es5/dashboard.v2.script.js"></script>

</asp:Content>
