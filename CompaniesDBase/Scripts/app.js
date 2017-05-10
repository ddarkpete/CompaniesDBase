var ViewModel = function () {
    var self = this;
    self.companies = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.newCompany = {
        CompanyName: ko.observable(),
        NIPNumber: ko.observable(),
        KRSNumber: ko.observable(),
        REGONNumber: ko.observable()
    }

    self.updateCompany = function (item) {

    }

    /*self.getCompany = function () {
        ajaxHelper(companiesUri + , 'GET').done(function (data) {
            self.detail(data);
        });
    }*/
    var companiesUri = '/api/companies/';

    self.addCompany = function (formElement) {
        var company = {
            CompanyName: self.newCompany.CompanyName(),
            NIPNumber: self.newCompany.NIPNumber(),
            KRSNumber: self.newCompany.KRSNumber(),
            REGONNumber: self.newCompany.REGONNumber()
        };

        ajaxHelper(companiesUri, 'POST', company).done(function (item) {
            self.companies.push(item);
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
        ajaxHelper(companiesUri +'?Id='+ $('#searchQuery').val(), 'GET').done(function (data) {
            self.companies(data);
        });
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

    function getAllCompanies() {
        ajaxHelper(companiesUri, 'GET').done(function (data) {
            self.companies(data);
        });
    }


    // Fetch the initial data.
    getAllCompanies();
};

ko.applyBindings(new ViewModel());