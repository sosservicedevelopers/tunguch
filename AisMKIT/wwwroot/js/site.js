// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//
function initInputJSON() {

    // get object
    var jsObj = getJsObj();

    // to json
    var json = JSON.stringify(jsObj);

    // init input
    document.querySelector('#CountriesAndRegisers').value = json;

    // send form
    document.querySelector('#sendFormBtn').click();
}

// Get values of selected options
function getJsObj() {

    // это js-Объект будет отправлен на сервер как JSON
    var countriesAndRegisers = { 'countries': [], 'regisers': [] };

    // all ids of selectLists
    var ids = ["countries", "regisers"];

    // перебор каждого id
    for (var i = 0; i < ids.length; i++) {

        //console.log(ids[i]);

        var selects = document.querySelectorAll("#" + ids[i] + " > select");

        // перебор каждого selectList
        for (var j = 0; j < selects.length; j++) {

            var options = selects[j].options;

            // перебор каждого option
            for (var t = 0; t < options.length; t++) {

                //console.log(options[t].selected);

                if (options[t].selected) {

                    // value - числа
                    var val = options[t].value / 1;

                    if (ids[i] == "countries") {
                        countriesAndRegisers.countries.push(val);
                    }

                    if (ids[i] == "regisers") {
                        countriesAndRegisers.regisers.push(val);
                    }

                }

            }

        }
    }

    return countriesAndRegisers;

}

function addSelectList(id) {

    var itm = document.querySelectorAll("#" + id + " > select")[0];
    var cln = itm.cloneNode(true);

    var br = document.createElement("br");
    document.getElementById(id).appendChild(br);
    document.getElementById(id).appendChild(cln);
}


