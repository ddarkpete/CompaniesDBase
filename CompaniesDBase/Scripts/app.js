var ViewModel = function () {
    var self = this;
    var companiesUri = '/api/companies/';
    var actual_id;

    self.companies = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.newCompany = {
        CompanyName: ko.observable(),
        NIPNumber: ko.observable(),
        KRSNumber: ko.observable(),
        REGONNumber: ko.observable()
    }

    self.getCompanyDetail = function (item) {
        ajaxHelper(companiesUri + item.Id, 'GET').done(function (data) {
            actual_id = item.Id;
            self.detail(data);
            var chdiv = document.getElementById("changeDiv");
            chdiv.hidden = false;
        });
    }

    self.addCompany = function (formElement) {

        var company = {
            CompanyName: self.newCompany.CompanyName(),
            NIPNumber: self.newCompany.NIPNumber(),
            KRSNumber: self.newCompany.KRSNumber(),
            REGONNumber: self.newCompany.REGONNumber()
        };

        ajaxHelper(companiesUri, 'POST', company).done(function (item) {
            self.companies.push(item);
            var addForm = document.getElementById("addDiv");
            addForm.hidden = true;
        });

        var form = document.getElementById("addForm");
        form.reset();
    }

    self.delCompany = function (item) {
        ajaxHelper(companiesUri + item.Id, 'DELETE').done(function (item) {
            self.companies.remove(item);
            getAllCompanies();
        });
    }

    searchCompany = function () {
        ajaxHelper(companiesUri + $('#searchPropDropdown').val() + '/' + $('#searchQuery').val(), 'GET').done(function (data) {
            self.companies(data);
        });
    }

    addEvent = function () {
        var addForm = document.getElementById("addDiv");
        addForm.hidden = false;
    }

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    self.updateCompany = function () {
        var company = {
            Id: actual_id,
            CompanyName: $('#changeForm').find('input[name="updateCompanyName"]').val(),
            NIPNumber: $('#changeForm').find('input[name="updateNIPNumber"]').val(),
            KRSNumber: $('#changeForm').find('input[name="updateKRSNumber"]').val(),
            REGONNumber: $('#changeForm').find('input[name="updateREGONNumber"]').val()
        };

        ajaxHelper(companiesUri + actual_id, 'PUT', company).done(function (item) {
            getAllCompanies();
            var form = document.getElementById("changeForm");
            form.reset();
            var chdiv = document.getElementById("changeDiv");
            chdiv.hidden = true;
        });
    }

    function getAllCompanies() {
        ajaxHelper(companiesUri, 'GET').done(function (data) {
            self.companies(data);
        });
    }


    // Fetch the initial data.
    getAllCompanies();
};

ko.applyBindings(new ViewModel());