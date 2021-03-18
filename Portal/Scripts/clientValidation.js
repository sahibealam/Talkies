function isNumericVal(obj) {
    var _value = obj.value;
    var dotcontains = _value.indexOf(".") != -1;
    var minuscontains = _value.indexOf("-") != -1;
    if (dotcontains)
        return true;
    if (minuscontains)
        return true;
    if ($.isNumeric(_value)) {
        return true;
    }
    else {
        obj.value = "";
        return false;
    }
}
///////////////////Only Numeric value
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
///////////////////Only Decimal value
function isNumberDecimalKey(evt, obj) {

    var charCode = (evt.which) ? evt.which : event.keyCode
    var value = obj.value;
    var dotcontains = value.indexOf(".") != -1;
    var minuscontains = value.indexOf("-") != -1;
    if (dotcontains)
        if (charCode == 46) return false;
    if (minuscontains)
        if (charCode == 189) return false;
    if (charCode == 46) return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

///////////////////CallRegistration
function validateSearch(obj) {
    if ($('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val() == "") {
        alert("Please Input Mobile No / Call Ref No!!");
        $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').focus();
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val().length == "10" || $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val().length == "13") {
        return true;
    }
    else {
        alert("Please Input Valid Mobile No / Call Ref No!!");
        $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').focus();
        return false;
    }
};

///////////////////RndAnalysisReason
function RndAnalysisReason(obj) {
    if ($('#ctl00_ContentPlaceHolder1_txtRndAnalysisReason').val() == "") {
        alert("Give Rnd Analysis Reason");
        
        return false;
    }
    return true;
};

function validateSave(obj) {
    return true;
};
function validateaddnew(obj) {
    return true;
};


///////////////////CallUnAssigned
function validateSearchUA(obj) {
    //if ($('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val() == "") {
    //    alert("Please Input Mobile No / Call Ref No!!");
    //    $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').focus();
    //    return false;
    //}
    //if ($('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val().length == "10" || $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val().length == "13") {
    //    return true;
    //}
    //else {
    //    alert("Please Input Valid Mobile No / Call Ref No!!");
    //    $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').focus();
    //    return false;
    //}
    return true;
};

///////////////////CallUpdation
function validateSearchUpdate(obj) {
    if ($('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val() == "") {
        alert("Please Input Mobile No / Call Ref No!!");
        $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').focus();
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val().length == "10" || $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val().length == "13" || $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').val().length == "12") {
        return true;
    }
    else {
        alert("Please Input Valid Mobile No / Call Ref No!!");
        $('#ctl00_ContentPlaceHolder1_txtSearchMobileNo').focus();
        return false;
    }
};

///////////////////MasterJurisdiction

function ValidateJurisdiction(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlParentJurisdiction').val() !== undefined && $('#ctl00_ContentPlaceHolder1_ddlParentJurisdiction').val() === "0") {
        alert("Select Parent Jurisdiction");
        return false;
    }
    else if ($('#ctl00_ContentPlaceHolder1_txtJurisdictionName').val() === "") {
        alert("Give Jurisdiction Name");
        return false;
    }
    return true;
};



///////////////////MasterDesignation

function ValidateDesignation(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtDesignation').val() === "") {
        alert("Give Designation");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_ddlDesignationLevel').val() === "0") {
        alert("Give Level");
        return false;
    }
    return true;
};


///////////////////Master ticket

function ValidateTicket(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlDepartment').val() === "0") {
        alert("Select Department");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtTktCategory').val() === "") {
        alert("Give TktCategory");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtTAT').val() === "") {
        alert("Give Tat");
        return false;
    }
    return true;
};

///////////////////MasterUNIT

function ValidateUnit(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtUnit').val() === "") {
        alert("Give Unit");
        return false;
    }
    
    return true;
};

///////////////////MasterFAILEDVISIT

function ValidateFailedvisit(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtFailedVisit').val() === "") {
        alert("Give FailedVisit Name");
        return false;
    }

    return true;
};

///////////////////MasterDSRStatus

function ValidateDSRStatus(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtDSRStatus').val() === "") {
        alert("Give DSR Status");
        return false;
    }

    return true;
};

////////////ValidateBranding
function ValidateBranding(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtBranding').val() === "") {
        alert("Give Branding");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtBrandingBudget').val() === "") {
        alert("Give Branding Budget");
        return false;
    }
    return true;
};

///////////////////////ValidateBeat
function ValidateBeat(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtBeatCode').val() === "") {
        alert("Give Beat Code");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtBeatFrom').val() === "") {
        alert("Give Beat From");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtBeatTill').val() === "") {
        alert("Give Beat To");
        return false;
    }

    if ($('#ctl00_ContentPlaceHolder1_ddlState').val() === "") {
        alert("Please Select State");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_ddlDistrict').val() === "") {
        alert("Please Select District");
        return false;
    }
    return true;
};

////////////ValidateRoute
function ValidateRoute(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlBeat').val() === "") {
        alert("Please Select Beat");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtRouteCode').val() === "") {
        alert("Give Route Code");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtDistanceApprox').val() === "") {
        alert("Give Distance Approx");
        return false;
    }

    if ($('#ctl00_ContentPlaceHolder1_txtBeatFrom').val() === "") {
        alert("Give Route Start");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtBeatTill').val() === "") {
        alert("Give Route End");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtAdditional').val() === "") {
        alert("Give Additional Detail");
        return false;
    }
    return true;
};


///////////////////MasterDepartment

function ValidateDepartment(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtDepartment').val() === "") {
        alert("Give Department");
        return false;
    }
    return true;
};
function ValidateHead(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtHeadName').val() === "") {
        alert("Give Head Name");
        return false;
    }
    return true;
};



///////////////////MasterRole

function ValidateMasterRole(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtRole').val() === "") {
        alert("Give Role");
        return false;
    }
    return true;
};


///////////////////Master Module Item

function ValidateMasterModuleItem(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlModule').val() === "0") {
        alert("Give Module");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtModuleItem').val() === "") {
        alert("Give Module Item");
        return false;
    }

    if ($('#ctl00_ContentPlaceHolder1_txtURL').val() === "") {
        alert("Give URL");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtOrder').val() === "") {
        alert("Give Order");
        return false;
    }
    return true;
};

///////////////////Master Type of Party

function ValidateMasterTypeOfParty(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtTypeofParty').val() === "") {
        alert("Give Type Of Party");
        return false;
    }
    return true;
};

///////////////////MasterBrand
function ValidateMasterBrand(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtBrand').val() === "") {
        alert("Give Brand");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_ddlState').val() === "0") {
        alert("Give State");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtYear').val() === "") {
        alert("Give Year");
        return false;
    }
    return true;
};
///////////////////Master Other Brand
function ValidateMasterOtherBrand(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtBrandOther').val() === "") {
        alert("Give Brand");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_ddlState').val() === "0") {
        alert("Select State");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtYear').val() === "") {
        alert("Select Year");
        return false;
    }
    return true;
};
///////////////////MasterLeave

function ValidateMasterLeave(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtTypeOfLeave').val() === "") {
        alert("Give Type Of Leave");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_TextAllowOfDays').val() === "") {
        alert("Give Allow Of Days");
        return false;
    }
    return true;
};

///////////////////Master Reaso Leave

function ValidateMasterReasonLeave(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlLeave').val() == 0 || $('#ctl00_ContentPlaceHolder1_ddlLeave').val() == null) {
        alert("Give Leave Type");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_TextSupportingReequired').val() === "") {
        alert("Give Supporting");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtReason').val() === "") {
        alert("Give Reason");
        return false;
    }
    return true;
};

///////////////////MasterPerson

function ValidatePerson(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlTypeofParty").val() == "0" || $("#ctl00_ContentPlaceHolder1_ddlTypeofParty").val() == null) {
        alert("Please Select Type of Party");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtPersonName").val() == "") {
        alert("Please Provide Employee Name");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtPersonFName").val() == "") {
        alert("Please Provide Employee Father's Name");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtMobileNo1").val() == "") {
        alert("Please Provide Employee Mobile No");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlDepartment").val() == "0") {
        alert("Please Select Department");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlDesignation").val() == "0") {
        alert("Please Select Designation");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlRole").val() == "0") {
        alert("Please Select Access Role");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "1" && $("#ctl00_ContentPlaceHolder1_ddlState").val() == "0") {
        alert("Please Select State");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "2" && $("#ctl00_ContentPlaceHolder1_ddlZone").val() == "0") {
        alert("Please Select Zone");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "3" && $("#ctl00_ContentPlaceHolder1_ddlDistrict").val() == "0") {
        alert("Please Select District");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "4" && $("#ctl00_ContentPlaceHolder1_ddlArea").val() == "0") {
        alert("Please Select Area");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlRole").val() == "2" && $("#ctl00_ContentPlaceHolder1_ddlDealer").val() == "0") {
        alert("Please Select Dealer");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlRole").val() == "3" && $("#ctl00_ContentPlaceHolder1_ddlServiceCenter").val() == "0") {
        alert("Please Select Service Center");
        return false;
    }
    return true;
};

///////////////////Master Employee Person

function ValidateEmployee(obj) {

   
    if ($("#ctl00_ContentPlaceHolder1_txtPersonName").val() == "") {
        alert("Please Provide Employee Name");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtPersonFName").val() == "") {
        alert("Please Provide Employee Father's Name");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtMobileNo1").val() == "") {
        alert("Please Provide Employee Mobile No");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlDepartment").val() == "0") {
        alert("Please Select Department");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlDesignation").val() == "0") {
        alert("Please Select Designation");
        return false;
    }
    
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "1" && $("#ctl00_ContentPlaceHolder1_ddlState").val() == "0") {
        alert("Please Select State");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "2" && $("#ctl00_ContentPlaceHolder1_ddlZone").val() == "0") {
        alert("Please Select Zone");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "3" && $("#ctl00_ContentPlaceHolder1_ddlDistrict").val() == "0") {
        alert("Please Select District");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlLevel").val() == "4" && $("#ctl00_ContentPlaceHolder1_ddlArea").val() == "0") {
        alert("Please Select Area");
        return false;
    }
    
    return true;
};

///////////////////ServiceCenterRegistration

function ValidateServiceCenterRegistration(obj) {
    if ($("#ctl00_ContentPlaceHolder1_ddlTypeofParty").val() == "0" || $("#ctl00_ContentPlaceHolder1_ddlTypeofParty").val()==null) {
        alert("Please Select Party");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtServiceCenterName").val() == "") {
        alert("Please Provide Service Center Name!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtMobileNo").val() == "") {
        alert("Please Provide Service Center Mobile No!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtAddress").val() == "") {
        alert("Please Provide Service Center Address!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlState").val() == "0") {
        alert("Please Provide Service Center State!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlDistrict").val() == "0") {
        alert("Please Provide Service Center District!");
        return false;
    }
    //if ($("#ctl00_ContentPlaceHolder1_txtUserName").val() == "") {
    //    alert("Please Provide User Name!");
    //    return false;
    //}
    if ($("#ctl00_ContentPlaceHolder1_txtOwnerName").val() == "") {
        alert("Please Provide Service Center Owner's Name!");
        return false;
    }
    return true;
};


///////////////////Logistics Fault Dispatch Reason Maste

function FaultDispatchStatus(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtLogisticsFaultDispatch').val() === "") {
        alert("Give Logistics Fault Dispatch Reason");
        return false;
    }
    return true;
};

///////////////////Logistics Fault Dispatch Reason Maste

function LogisticsGenerateVoucher(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtVoucherNo').val() === "") {
        alert("Please Provide Voucher No.");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtNarration').val() === "") {
        alert("Please Provide Narration.");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtProcessingDate').val() === "") {
        alert("Please Select A Valid Date.");
        return false;
    }
    return true;
};
///////////////////PaymentVoucher
function PaymentVoucher(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtPaymentDate').val() === "") {
        alert("Please Select A Valid Date.");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtReceiptNo').val() === "") {
        alert("Please Provide Receipt No.");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtComments').val() === "") {
        alert("Please Provide Payment Narration ");
        return false;
    }
    return true;
};



///////////////////MasterShape

function ValidateShape(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtShape').val() === "") {
        alert("Give Product Shape");
        return false;
    }
    return true;
};

///////////////////WarrentyReason

function WarrentyReason(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtWarrentyReason').val() === "") {
        alert("Give Warrenty Reason");
        return false;
    }
    return true;
};


//////////////ValidateAssign

function ValidateAssign(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlServiceCenter').val() === "") {
        alert("Select Service Center");
        return false;
    }
    return true;
};

//////////validateSearchdealer
function validateSearchdealer(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlDealerMaster').val() === "") {
        alert("Please Select Any Dealer / Retailer!");
        return false;
    }
    return true;
};

////////////////////////validateEngineer
function validateEngineer(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlPersonS').val() === "") {
        alert("Please Select Engineer!");
        return false;
    }
    return true;
};

///////////////////MasterColor

function ValidateColor(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtColor').val() === "") {
        alert("Give Product Color");
        return false;
    }
    return true;
};


/////////////////ValidateProblemType

function ValidateProblemType(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtProblemType').val() === "") {
        alert("Give Problem  Type");
        return false;
    }
    return true;
};


/////////////////Video Tutorial

function ValidateVideoTutorial(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtVideoTutorials').val() === "") {
        alert("Give VideoTutorials Name");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtYouTubeURL').val() === "") {
        alert("Give VideoTutorials URL");
        return false;
    }
    return true;
};
/////////////////ValidateAnalysistype

function Validateproblemtype(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtAnalysisType').val() === "") {
        alert("Give Analysis Type");
        return false;
    }

    if ($('#ctl00_ContentPlaceHolder1_txtBrandOther').val() === "") {
        alert("Give Brand Other Name");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtVideoTutorials').val() === "") {
        alert("Give Brand Other Name");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtYouTubeURL').val() === "") {
        alert("Give Brand Other Name");
        return false;
    }
    return true;
};



///////////////////MasterBrand

function ValidateBrand(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtBrand').val() === "") {
        alert("Give Brand");
        return false;
    }
    return true;
};



///////////////////MasterBrand

function BatchCreate(obj) {

    if ($('#ctl00_ContentPlaceHolder1_txtYear').val() === "") {
        alert("Give Year");
        return false;
    }
    return true;
};


///////////////////MasterCategory

function ValidateCategory(obj) {

    if ($('#ctl00_ContentPlaceHolder1_ddlBrand').val() === "0") {
        alert("Please Select Brand");
        return false;
    }
    if ($('#ctl00_ContentPlaceHolder1_txtCategoryName').val() === "") {
        alert("Give Product Category");
        return false;
    }
    return true;
};

///////////////////MasterProduct

function ValidateProduct(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlCategory").val() == 0) {
        alert("Please Select Category");
        return false;
    }
   
        if ($("#ctl00_ContentPlaceHolder1_txtProduct").val() == "") {
        alert("Please Fill Product");
            return false;

    }

    if ($("#ctl00_ContentPlaceHolder1_txtProductCommon").val() == "") {
        alert("Please Fill Common  Product");
        return false;
    }
    return true;
};

///////////////////ModelSpecificationCatalauge

function ModelSpecificationCatalauge(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlProduct").val() == 0) {
        alert("Please Select  Model");
        return false;
    }

    if ($("#ctl00_ContentPlaceHolder1_txtPartNo").val() == "") {
        alert("Please Fill Part No*");
        return false;

    }

    if ($("#ctl00_ContentPlaceHolder1_txtWatt").val() == "") {
        alert("Please Fill Wattage");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtLumen").val() == "") {
        alert("Please Fill   Lumen");
        return false;
   
    }
    if ($("#ctl00_ContentPlaceHolder1_txtDimention").val() == "") {
        alert("Please Fill Dimention");
        return false;
    }
    return true;
};




///////////////////MasterModel

function ValidateModel(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlProduct").val() == 0) {
        alert("Please Select Category");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtModelName").val() == "") {
        alert("Please Fill Model");
        return false;
    }

    return true;
};


///////////////////ValidatePartType

function ValidatePartType(obj) {

   
    if ($("#ctl00_ContentPlaceHolder1_txtPartType").val() == "") {
        alert("Please Fill Part Group Name");
        return false;
    }
    return true;
};

///////ModelBatchParttypelinking

function ModelBatchParttypelinking(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlCategory").val() == 0) {
        alert("Please Select Category");
        return false;
    }
    return true;
};


///////MasterChildRawMaterial

function MasterChildRawMaterial(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlPartGroup").val() == 0) {
        alert("Please Select Part Group");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtPartNo").val() == 0) {
        alert("Please Give Part No");
        return false;
    }
    return true;
};
///////MasterBOMConfig

function MasterBOMConfig(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlCategory").val() == 0) {
        alert("Please Select Part Category");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlPartGroup").val() == 0) {
        alert("Please Select Part Group");
        return false;
    }

    if ($("#ctl00_ContentPlaceHolder1_ddlModel").val() == 0) {
        alert("Please Select Model");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlShape").val() == 0) {
        alert("Please Select Shape");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlColor").val() == 0) {
        alert("Please Select Color");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlPartNoMaster").val() == 0) {
        alert("Please Select Part No");
        return false;
    }   
    return true;
};



///////////////////MasterBatch

function ValidateBatch(obj) {

    if ($("#ctl00_ContentPlaceHolder1_txtDate").val() == "") {
        alert("Please Select Date!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtBatchNo").val() == "") {
        alert("Please Give Batch No!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlBrand").val() == "0") {
        alert("Please Select Brand!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlCategory").val() == "0") {
        alert("Please Select Category!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtMRP").val() == "0") {
        alert("Please Give Product MRP!!");
        return false;
    }

    if ($("#ctl00_ContentPlaceHolder1_txtDealerPrice").val() == "0") {
        alert("Please Give Product Dealer Price!!");
        return false;
    }

    if ($("#ctl00_ContentPlaceHolder1_txtRetailerPrice").val() == "0") {
        alert("Please Give Product Retailer Price!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlProduct").val() == "0") {
        alert("Please Select Product!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_ddlModel").val() == "0") {
        alert("Please Select Model!!");
        return false;
    }
    return true;
};

///////////////////MasterBarcodeStock

function ValidateBarcodeStock(obj) {

    if ($("#ctl00_ContentPlaceHolder1_hf_BatchNoDetails_Id").val() == "-1") {
        alert("Please Select A Batch!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtBarCode").val() == "") {
        alert("Please Give Bar Code No!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtMRP").val() == "") {
        alert("Please Give Product MRP!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtSP").val() == "") {
        alert("Please Give Product SP!!");
        return false;
    }
    return true;
};

///////////////////StockTransfer

function ValidateStockTransfer(obj) {

    if ($("#ctl00_ContentPlaceHolder1_txtDate").val() == "") {
        alert("Please Select Date!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtInvoiceNo").val() == "") {
        alert("Please Give Invoice No!!");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_grdProductListTransfer").val() == 0) {
        alert("Please Add Atlease One Item To Transfer!!");
        return false;
    }
    return true;
};

///////////////////MasterSymptomCode

function ValidateSymptomCode(obj) {

    if ($("#ctl00_ContentPlaceHolder1_txtSymptomCode").val() == "") {
        alert("Give Symptom Code");
        return false;
    }
    return true;
};

///////////////////MasterDefectCode

function ValidateDefectCode(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlSymptomCode").val() == "0") {
        alert("Please Select Symptom Code");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtDefectCodeName").val() == "") {
        alert("Give Defect Code");
        return false;
    }
    return true;
};

///////////////////MasterRepairCode

function ValidateRepairCode(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlDefectCode").val() == "0") {
        alert("Please Select Defect Code");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtRepairCodeName").val() == "") {
        alert("Give Repair Code");
        return false;
    }
    return true;
};

///////////////////MasterCallClosureType

function ValidateCallClosureType(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlPendingReason").val() == "0") {
        alert("Please Select Pending Reason");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtClosureDiscriptionTypeName").val() == "") {
        alert("Give Call Closure Discription Type");
        return false;
    }
    return true;
};

///////////////////MasterCallClosureTypeDesc

function ValidateCallClosureTypeDesc(obj) {

    if ($("#ctl00_ContentPlaceHolder1_ddlClosureDiscriptionType").val() == "0") {
        alert("Please Select Closure Description Type");
        return false;
    }
    if ($("#ctl00_ContentPlaceHolder1_txtClosureDiscriptionTypeDesc_Name").val() == "") {
        alert("Give Call Closure Discription Type Description Name");
        return false;
    }
    return true;
};

///////////////////MasterCallClosureStatus

function ValidateCallClosureStatus(obj) {

    if ($("#ctl00_ContentPlaceHolder1_txtCallClosureStatus").val() == "") {
        alert("Give Call Closure Status");
        return false;
    }
    return true;
};
