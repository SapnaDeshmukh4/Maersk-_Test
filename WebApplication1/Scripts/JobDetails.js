var JobDetails = function () {

    var bindForm = function (id) {
        $('.overlap_container').show();
        $.ajax({
            type: 'GET',
            url: window.GetForm,
            async: false,
            //data: { buildingSpaceDetailsId: id },
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (response) {
                alert(response)
            },
            error: function (data) {
                HideLoadder();
                alert(window.ErrorMsg);
            }
        });
    }

    return {
        Load: function () {
         

            $(document).on("click", "#AddEdit", function () {
                $('.overlap_container').show();
                bindForm(-1);
            });
            
        },

    }

}();