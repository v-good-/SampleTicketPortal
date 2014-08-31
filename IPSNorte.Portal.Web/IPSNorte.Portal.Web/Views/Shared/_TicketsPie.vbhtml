<div id="placeholder" style="height:150px;text-align:center;margin:10px">
</div>

    <script type="text/javascript">
        var data = [
            { label: resources.ticketStatusOpen, data: 15, color: "green" },
            { label: resources.ticketStatusInProgress, data: 20, color: "blue" },
            { label: resources.ticketStatusClosed, data: 65, color: "red" },
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
