<div id="placeholder" style="height:150px;text-align:center;margin:10px">
</div>

    <script type="text/javascript">
        var data = [
            { label: "Open", data: 34.5, color: "green" },
            { label: "Closed", data: 65.5, color: "#80699B" },
        ];

        $(document).ready(function () {
            $.plot($("#placeholder"), data, {
                series: {
                    pie: {
                        show: true
                    }
                },
                legend: {
                    labelBoxBorderColor: "none"
                }
            });
        });
    </script>
