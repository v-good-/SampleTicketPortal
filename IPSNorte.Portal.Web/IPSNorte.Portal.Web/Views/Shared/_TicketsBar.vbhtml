

<div style="height:150px;text-align:center;margin:10px">
    <div id="flot-placeholder" style="width:100%;height:100%;"></div>
</div>

<script type="text/javascript">

    var data = [[0, 11], [1, 15], [2, 25], [3, 24]];
    var dataset = [{ data: data, color: "#5482FF" }];
    var ticks = [[0, "Low"], [1, "Medium"], [2, "High"], [3, "Critical"]];

    var options = {
        series: {
            bars: {
                show: true
            }
        },
        bars: {
            align: "center",
            barWidth: 0.3
        },
        xaxis: {
            axisLabel: "Priorities",
            axisLabelUseCanvas: true,
            axisLabelFontSizePixels: 12,
            axisLabelPadding: 10,
            ticks: ticks
        },
        yaxis: {
            axisLabel: "# tickets",
            axisLabelUseCanvas: true,
            axisLabelFontSizePixels: 12,
            axisLabelPadding: 3
        },
        legend: {
            noColumns: 0,
            labelBoxBorderColor: "#000000",
            position: "nw"
        },
        grid: {
            hoverable: true,

        }
    };

    $(document).ready(function () {
        $.plot($("#flot-placeholder"), dataset, options);
    });

    function gd(year, month, day) {
        return new Date(year, month, day).getTime();
    }
    
</script>
