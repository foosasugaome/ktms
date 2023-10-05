<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ktms.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var TestTypeChartData = [];
        var PassChartBar = [];
        var FailChartBar = [];
    </script>
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
                        <div class="card-title">User Report</div>
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
    <%--<script src="assets/js/es5/dashboard.v1.script.js"></script>--%>
    <%--<script src="assets/js/vendor/datatables.min.js"></script>--%>
    <%--<script src="assets/js/es5/dashboard.v2.script.js"></script>--%>

    <script>
        'use strict';

        var _extends = Object.assign || function (target) { for (var i = 1; i < arguments.length; i++) { var source = arguments[i]; for (var key in source) { if (Object.prototype.hasOwnProperty.call(source, key)) { target[key] = source[key]; } } } return target; };

        $(document).ready(function () {

            // User Report Chart
            var echartElemBar = document.getElementById('echartBar');
            if (echartElemBar) {
                var echartBar = echarts.init(echartElemBar);
                echartBar.setOption({
                    legend: {
                        borderRadius: 0,
                        orient: 'horizontal',
                        x: 'right',
                        data: ['Pass', 'Fail']
                    },
                    grid: {
                        left: '8px',
                        right: '8px',
                        bottom: '0',
                        containLabel: true
                    },
                    tooltip: {
                        show: true,
                        backgroundColor: 'rgba(0, 0, 0, .8)'
                    },
                    xAxis: [{
                        type: 'category',
                        data: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                        axisTick: {
                            alignWithLabel: true
                        },
                        splitLine: {
                            show: false
                        },
                        axisLine: {
                            show: true
                        }
                    }],
     
                    yAxis: [{
                        type: 'value',
                        axisLabel: {
                            formatter: '{value}'
                        },
                        min: 0,
                        max: 10,
                        interval: 2,
                        axisLine: {
                            show: false
                        },
                        splitLine: {
                            show: true,
                            interval: 'auto'
                        }
                    }],

                    series: [{
                        name: 'Pass',
                        data: PassChartBar,
                        label: { show: false, color: '#0168c1' },
                        type: 'bar',
                        barGap: 0,
                        color: '#bcbbdd',
                        smooth: true,
                        itemStyle: {
                            emphasis: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowOffsetY: -2,
                                shadowColor: 'rgba(0, 0, 0, 0.3)'
                            }
                        }
                    }, {
                        name: 'Fail',
                        data: FailChartBar,
                        label: { show: false, color: '#639' },
                        type: 'bar',
                        color: '#7569b3',
                        smooth: true,
                        itemStyle: {
                            emphasis: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowOffsetY: -2,
                                shadowColor: 'rgba(0, 0, 0, 0.3)'
                            }
                        }
                    }]
                });
                $(window).on('resize', function () {
                    setTimeout(function () {
                        echartBar.resize();
                    }, 500);
                });
            }

            // Test type pie chart
            var echartElemPie = document.getElementById('echartPie');
            if (echartElemPie) {
                var echartPie = echarts.init(echartElemPie);
                echartPie.setOption({
                    color: ['#62549c', '#7566b5', '#7d6cbb', '#8877bd', '#9181bd', '#6957af'],
                    tooltip: {
                        show: true,
                        backgroundColor: 'rgba(0, 0, 0, .8)'
                    },

                    series: [{
                        name: 'Test Types',
                        type: 'pie',
                        radius: '60%',
                        center: ['50%', '50%'],
                        data: TestTypeChartData,
                        itemStyle: {
                            emphasis: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowColor: 'rgba(0, 0, 0, 0.5)'
                            }
                        }
                    }]
                });
                $(window).on('resize', function () {
                    setTimeout(function () {
                        echartPie.resize();
                    }, 500);
                });
            }

            //var echartElem4 = document.getElementById('echart4');
            //if (echartElem4) {
            //    var echart4 = echarts.init(echartElem4);
            //    echart4.setOption(_extends({}, echartOptions.lineNoAxis, {
            //        series: [{
            //            data: [4, 8, 10, 6, 12, 4, 5],
            //            lineStyle: {
            //                color: 'rgba(102, 51, 153, .86)',
            //                width: 3,
            //                shadowColor: 'rgba(0, 0, 0, .2)',
            //                shadowOffsetX: -1,
            //                shadowOffsetY: 8,
            //                shadowBlur: 10
            //            },
            //            label: { show: true, color: '#212121' },
            //            type: 'line',
            //            smooth: true,
            //            itemStyle: {
            //                borderColor: 'rgba(69, 86, 172, 0.86)'
            //            }
            //        }]
            //    }, {
            //        xAxis: { data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'] }
            //    }));
            //    $(window).on('resize', function () {
            //        setTimeout(function () {
            //            echart4.resize();
            //        }, 500);
            //    });
            //}



            // Chart in Dashboard version 1
            var echartElem1 = document.getElementById('echart1');
            if (echartElem1) {
                var echart1 = echarts.init(echartElem1);
                echart1.setOption(_extends({}, echartOptions.lineFullWidth, {
                    series: [_extends({
                        data: [30, 40, 20, 50, 40, 80, 90]
                    }, echartOptions.smoothLine, {
                        markArea: {
                            label: {
                                show: true
                            }
                        },
                        areaStyle: {
                            color: 'rgba(102, 51, 153, .2)',
                            origin: 'start'
                        },
                        lineStyle: {
                            color: '#663399'
                        },
                        itemStyle: {
                            color: '#663399'
                        }
                    })]
                }));
                $(window).on('resize', function () {
                    setTimeout(function () {
                        echart1.resize();
                    }, 500);
                });
            }
            // Chart in Dashboard version 1
            var echartElem2 = document.getElementById('echart2');
            if (echartElem2) {
                var echart2 = echarts.init(echartElem2);
                echart2.setOption(_extends({}, echartOptions.lineFullWidth, {
                    series: [_extends({
                        data: [30, 10, 40, 10, 40, 20, 90]
                    }, echartOptions.smoothLine, {
                        markArea: {
                            label: {
                                show: true
                            }
                        },
                        areaStyle: {
                            color: 'rgba(255, 193, 7, 0.2)',
                            origin: 'start'
                        },
                        lineStyle: {
                            color: '#FFC107'
                        },
                        itemStyle: {
                            color: '#FFC107'
                        }
                    })]
                }));
                $(window).on('resize', function () {
                    setTimeout(function () {
                        echart2.resize();
                    }, 500);
                });
            }
            // Chart in Dashboard version 1
            var echartElem3 = document.getElementById('echart4');
            if (echartElem3) {
                var echart3 = echarts.init(echartElem3);
                echart3.setOption(_extends({}, echartOptions.lineNoAxis, {
                    series: [{
                        data: [40, 80, 20, 90, 30, 80, 40, 90, 20, 80, 30, 45, 50, 110, 90, 145, 120, 135, 120, 140],
                        lineStyle: _extends({
                            color: 'rgba(102, 51, 153, 0.8)',
                            width: 3
                        }, echartOptions.lineShadow),
                        label: { show: true, color: '#212121' },
                        type: 'line',
                        smooth: true,
                        itemStyle: {
                            borderColor: 'rgba(102, 51, 153, 1)'
                        }
                    }]
                }));
                $(window).on('resize', function () {
                    setTimeout(function () {
                        echart3.resize();
                    }, 500);
                });
            }

            //// Chart in Dashboard version 2
            //var echartElem4 = document.getElementById('echart4');
            //if (echartElem4) {
            //    var echart4 = echarts.init(echartElem4);
            //    echart4.setOption(_extends({}, echartOptions.lineNoAxis, {
            //        series: [{
            //            data: [4, 8, 10, 6, 12, 4, 5],
            //            lineStyle: {
            //                color: 'rgba(102, 51, 153, .86)',
            //                width: 3,
            //                shadowColor: 'rgba(0, 0, 0, .2)',
            //                shadowOffsetX: -1,
            //                shadowOffsetY: 8,
            //                shadowBlur: 10
            //            },
            //            label: { show: true, color: '#212121' },
            //            type: 'line',
            //            smooth: true,
            //            itemStyle: {
            //                borderColor: 'rgba(69, 86, 172, 0.86)'
            //            }
            //        }]
            //    }, {
            //        xAxis: { data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'] }
            //    }));
            //    $(window).on('resize', function () {
            //        setTimeout(function () {
            //            echart4.resize();
            //        }, 500);
            //    });
            //}

        });
    </script>

</asp:Content>
