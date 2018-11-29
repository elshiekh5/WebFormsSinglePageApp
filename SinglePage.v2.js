///////////////////////////////////////////////
//Update inner content
///////////////////////////////////////////////
//Maarif base elements
var $iconsDiv = null;
var $iconsDivAlert = null;
var $traceBackLinks = null;
var $innerContentDiv = null;
var $iconsContentDiv = null;
var baseAppUrl = 'http://http://localhost:25698/';
var PageTitle = null;
var SiteTitle = null;
var RedirectUrl = null;
var $modal_message = null;

function getAllInternalLinks($containerelement) {
    /*var $allLinks = $($containerelement).find("a[href^='http://http://localhost:25698/'], a[href^='//surveys.maarif.com.local/'], a[href^='surveys.maarif.com.local/'], a[href^='/'], a[href^='./'], a[href^='../'], a[href^='#']").not(function () {
        return $(this).attr('href').match(/\.(pdf|mp3|jpg|jpeg|etc)$/i);
    });*/
    var $allLinks = $($containerelement).find("a");
    $allLinks = $allLinks.not(".notAjaxRequest");
    return $allLinks;
}

function updatePageTitle() {
    if (PageTitle != null) {
        document.title = SiteTitle + ' | ' + PageTitle;
        $(".TraceBackContainer").find("span").remove();
        $(".TraceBackContainer").append('<span class=TraceBackCurrent "style="">' + PageTitle + '</span>');
    }
    else {
        document.title = SiteTitle;
        $(".TraceBackContainer").find("span").remove();
    }
}




function AttachSinglePageBehaviour($containerelement) {
    debugger;
    //catch all inner links in the inner content
    var $allLinks = getAllInternalLinks($containerelement);
    //catch all forms in the inner content
    var $forms = $($containerelement).find("form");
    //UpdateAnckorToUseAjax
    UpdateAnckorToUseAjax($allLinks);
    //makeFormsUsesAjaxPost($forms);
    makeAspWebFormsUseAjaxPost();
    //$("#innerContent2").show();
}

///////////////////////////////////////////////
//LoadUrlinAjaxMode
///////////////////////////////////////////////
function LoadUrlinAjaxMode(url) {
    debugger;

    //window.location.hash = url;
    $($iconsContentDiv).hide("fast");
    //loading ....
    $("#innerContentDiv").html('<div class="loadersmall"></div>');
    //get the new content
    $($innerContentDiv).load(url, function (response, status, xhr) {
        if (status == "error") {
            $($iconsContentDiv).fadeIn();
            var msg = "Sorry but there was an error: ";
            $("#error").html(msg + xhr.status + " " + xhr.statusText);
        }
        else {

            AttachSinglePageBehaviour($innerContentDiv);
            updatePageTitle();
        }
    });

}
///////////////////////////////////////////////



///////////////////////////////////////////////
//UpdateAnckorToUseAjax
///////////////////////////////////////////////
function UpdateAnckorToUseAjax($internalLinks) {
    var ev = null;
    $($internalLinks).each(function (index) {
        //debugger;

        ev = $._data($(this)[0], 'events');
        if (ev && ev.click) {
            //$(this).attr("ajax", "unbinded");
            //$(this).addClass("NoAjaxunBinded");
            return;
        }
        //$(this).attr("ajax", "binded");
        //$anchor.unbind("click");
        var url = $(this).attr("href");
        $(this).attr("href", "#url=" + url);

        /*
        $(this).click(function (e) {
            e.preventDefault();
            var url = $(this).attr("href");
            //LoadUrlinAjaxMode(url);
            
            changeViewLocation(url);
            return false;
        });*/
    });



}
///////////////////////////////////////////////


/*////////////////////////////////////////////////////////////////////*/
//Override form submit
function makeMVCFormsUsesAjaxPost($forms) {
    //----------------------------------------------------
    $forms.submit(function (event) {
        alert("teeet");
        //debugger;
        event.preventDefault();
        var form = $(this);
        $.ajax({
            url: form.attr('action'), // Get the action URL to send AJAX to
            type: "POST",
            data: form.serialize(), // get all form variables
            success: function (result) {
                // ... do your AJAX post result
                console.log(result);
                $($innerContentDiv).html(result);
                AttachSinglePageBehaviour($innerContentDiv);
            }
        });
    });
    //----------------------------------------------------
}
function makeAspWebFormsUseAjaxPost() {
    //----------------------------------------------------
    if (document.forms['formInternal']) {
        //var url = $("#formInternal").attr('action');
        var url = CatchUrlToRedirect();
        debugger;
        //---------------------------------
        //override auto post back behaviour
        document.forms['formInternal'].submit = function () {
            WebFormSubmitter(url,null, null);
            return false;
        }
        //---------------------------------
        //override any submit button behaviour
        $("#formInternal").find("input[type=submit]").click(function (e) {
            e.preventDefault();
            WebFormSubmitter(url, $(this), e);
        });
        //---------------------------------
        //just to be insure
        $("#formInternal").on("submit", function (event) {
            debugger;
            WebFormSubmitter(url, null, null);
        });
        //----------------------------------------------------
    }
}
//---------------------------------------
//WebFormSubmitter
//---------------------------------------
function WebFormSubmitter(url, $btn, event) {
    debugger;

    if (event) {
        event.preventDefault();
    }
    var data = $('#formInternal').serialize();
    if ($btn) {
        data += "&" + $($btn).attr('name') + "=" + $($btn).val();
        console.log("data");
        console.log(data);
    }
    $.ajax({
        type: 'POST',
        url: url,
        data: data,
        success: function (result) {
            debugger;
            $("#innerContentDiv").html("");

            // ... do your AJAX post result
            console.log(result);
            $("#innerContentDiv").html(result);
            AttachSinglePageBehaviour($innerContentDiv);
        },
        error: function (xhr, status, error) {
            debugger;
            $("#innerContentDiv").prepend('<div class="alert alert-danger text-center" role="alert">' + error + '</div>');
            
    }
    });
    return false;

}
//---------------------------------------
function changeViewLocation(url) {
    alert("changeViewLocation  : " + url)
    //window.location.hash = url;
    gotoHASH(url);
}

function gotoHASH(url) {
    url = "#" + url;
    if (url) {
        window.location.href = url;
    }
};

/*////////////////////////////////////////////////////////////////////*/
function CatchUrlToRedirect() {
    var url = location.hash;
    url = decodeURIComponent(url);
    if (url.startsWith('#url=')) {
        url = url.replace("#url=", "");
    }
    else if (url.startsWith('#!#url=')) {
        url = url.replace("#!#url=", "");
    }
    else {
        url = null;
    }
    return url
}

function urlChanged(url) {
    if (url.length > 0) {

        if (url == "/homeicons") {
            $innerContentDiv.html("");
            $($iconsContentDiv).fadeIn();
        }
        else {
            LoadUrlinAjaxMode(url);
        }
    }

}

function checkUrl() {

    var url = CatchUrlToRedirect();
    if (url && url != null) {
        urlChanged(url);

    }
    else
    {
        if (hasRedirecturl == false) {
            // window.location.hash = "/homeicons";
            window.location ="/default#!#url=%2Fhomeicons"
        }
    }
}

$(document).ready(function () {
    debugger;
    var weGotTheIcons = false;
    var weGotTheTracBackLinks = false;
    $innerContentDiv = $("#innerContentDiv");
    $wrapper = $("#wrapper");
    //$modal_message = $("#modal_message");
    //$('#messagemodal').modal();

    if (hasRedirecturl == false) {
        
        AttachSinglePageBehaviour($wrapper);
        var url = CatchUrlToRedirect();
        if (url && url != null) {
            urlChanged(url);
        }
    }
    else {

        //window.location.replace("/home/#url=" + redirectUrl);

        LoadUrlinAjaxMode(redirectUrl);
    }


    $(window).on('hashchange', function () {
        debugger;
        checkUrl();
    });
    debugger;
    
    checkUrl();
});

