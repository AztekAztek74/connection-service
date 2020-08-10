function Validations() {
  let form = document.querySelector("form");

  let validText = document.getElementById("validation");

  switch (form.id) {
    case "customerData":
      let FullName = document.getElementById("FullName").value;
      let address = document.getElementById("address").value;
      let Phone = document.getElementById("Phone").value;
      let HandlingReason = document.getElementById("HandlingReason").value;
      let city = document.getElementById("city").value;
      if (
        FullName == "" ||
        address == "" ||
        Phone == "" ||
        HandlingReason == "" ||
        city == ""
      ) {
        validText.innerHTML = "Пожалуйста, заполните обязательные (*) поля";
        document
          .getElementById("transitionTarif")
          .setAttribute("disabled", true);
      }
      if (
        !FullName == "" &&
        !address == "" &&
        !Phone == "" &&
        !HandlingReason == "" &&
        !city == ""
      ) {
        validText.innerHTML = "";
        document.getElementById("transitionTarif").removeAttribute("disabled");
      }
      if (Phone == "") {
        document
          .getElementById("earlyCompletion")
          .setAttribute("disabled", true);
      }
      if (!Phone == "") {
        document.getElementById("earlyCompletion").removeAttribute("disabled");
      }
      break;

    case "selectTariffs":
      let selecrTarrifs = [];
      let checkboxes = document.querySelectorAll(
        "input[type=checkbox]:checked"
      );
      for (let i = 0; i < checkboxes.length; i++) {
        selecrTarrifs.push(checkboxes[i].id);
      }
      if (selecrTarrifs.length) {
        document
          .getElementById("transitionConfirm")
          .removeAttribute("disabled");
      } else {
        document
          .getElementById("transitionConfirm")
          .setAttribute("disabled", true);
      }
      break;
    case "earlyCompletion":
      if (document.getElementById("EarlyCompletionCause").value == "") {
        document
          .getElementById("completionReqest")
          .setAttribute("disabled", true);
      } else {
        document.getElementById("completionReqest").removeAttribute("disabled");
      }
  }
}

window.Validations = Validations;
