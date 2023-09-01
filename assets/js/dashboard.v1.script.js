$(document).ready(function() {

    // Chart in Dashboard version 1
    let echartElemBar = document.getElementById('echartBar');
    if (echartElemBar) {
        let echartBar = echarts.init(echartElemBar);
        echartBar.setOption({
            legend: {
                borderRadius: 0,
                orient: 'horizontal',
                x: 'right',
                data: ['Online', 'Offline']
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
                data: ['Test', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec'],
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
                        formatter: '${value}'
                    },
                    min: 0,
                    max: 100000,
                    interval: 25000,
                    axisLine: {
                        show: false
                    },
                    splitLine: {
                        show: true,
                        interval: 'auto'
                    }
                }

            ],

            series: [{
                name: 'Pass',
                data: [15, 69, 22, 60, 50, 50, 30, 80, 70, 60, 20, 30],
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
                data: [45, 82, 35, 93, 71, 89, 49, 91, 82, 86, 35, 40],
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
        $(window).on('resize', function() {
            setTimeout(() => {
                echartBar.resize();
            }, 500);
        });
    }

    // Chart in Dashboard version 1
    let echartElemPie = document.getElementById('echartPie');
    if (echartElemPie) {
        let echartPie = echarts.init(echartElemPie);
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
                    data: [
                        { value: 535, name: 'Class 7 - French' },
                        { value: 310, name: 'Class 5 - English' },
                        { value: 234, name: 'Class 5 - French' },
                        { value: 155, name: 'Class 7 - English' }                        
                    ],
                    itemStyle: {
                        emphasis: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }

            ]
        });
        $(window).on('resize', function() {
            setTimeout(() => {
                echartPie.resize();
            }, 500);
        });
    }

    // Chart in Dashboard version 1
    let echartElem1 = document.getElementById('echart1');
    if (echartElem1) {
        let echart1 = echarts.init(echartElem1);
        echart1.setOption({
            ...echartOptions.lineFullWidth,
            ... {
                series: [{
                    data: [30, 40, 20, 50, 40, 80, 90],
                    ...echartOptions.smoothLine,
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
                        color: '#663399',
                    },
                    itemStyle: {
                        color: '#663399'
                    }
                }]
            }
        });
        $(window).on('resize', function() {
            setTimeout(() => {
                echart1.resize();
            }, 500);
        });
    }
    // Chart in Dashboard version 1
    let echartElem2 = document.getElementById('echart2');
    if (echartElem2) {
        let echart2 = echarts.init(echartElem2);
        echart2.setOption({
            ...echartOptions.lineFullWidth,
            ... {
                series: [{
                    data: [30, 10, 40, 10, 40, 20, 90],
                    ...echartOptions.smoothLine,
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
                }]
            }
        });
        $(window).on('resize', function() {
            setTimeout(() => {
                echart2.resize();
            }, 500);
        });
    }
    // Chart in Dashboard version 1
    let echartElem3 = document.getElementById('echart3');
    if (echartElem3) {
        let echart3 = echarts.init(echartElem3);
        echart3.setOption({
            ...echartOptions.lineNoAxis,
            ... {
                series: [{
                    data: [40, 80, 20, 90, 30, 80, 40, 90, 20, 80, 30, 45, 50, 110, 90, 145, 120, 135, 120, 140],
                    lineStyle: {
                        color: 'rgba(102, 51, 153, 0.8)',
                        width: 3,
                        ...echartOptions.lineShadow
                    },
                    label: { show: true, color: '#212121' },
                    type: 'line',
                    smooth: true,
                    itemStyle: {
                        borderColor: 'rgba(102, 51, 153, 1)'
                    }
                }]
            }
        });
        $(window).on('resize', function() {
            setTimeout(() => {
                echart3.resize();
            }, 500);
        });
    }

});