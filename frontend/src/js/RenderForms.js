const BASE_PATH = "http://localhost:50383/api";

let isLoad = false;

let stepBid = "customerData";

let tariffs = [];

let activeCity;
let FullName = "";
let address = "";
let Phone = "";
let AdditionalPhone = "";
let Coment = "";
let HandlingReason;
let selecrTarrifs = [];
let data = {};

async function GetTariffs() {
  await fetch(`${BASE_PATH}/Tariffs/${activeCity}`)
    .then((res) => res.json())
    .then((result) => (tariffs = result))
    .catch((err) => err);
}

async function postRequest(controller) {
  await fetch(`${BASE_PATH}/${controller}`, {
    method: "POST",
    body: JSON.stringify(data),
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  });
}

const changeStepBid = (step) => {
  stepBid = step;
  update();
};

const transitionTariffs = async () => {
  FullName = document.getElementById("FullName").value;
  address = document.getElementById("address").value;
  Phone = document.getElementById("Phone").value;
  AdditionalPhone = document.getElementById("AdditionalPhone").value;
  activeCity = document.getElementById("city").value;
  Coment = document.getElementById("Coment").value;
  HandlingReason = document.getElementById("HandlingReason").value;
  await GetTariffs();
  changeStepBid("selectTariffs");
};

const transitionEarlyCompletions = () => {
  Phone = document.getElementById("Phone").value;
  changeStepBid("earlyCompletion");
};

const connectionReqest = () => {
  data.Address = `${activeCity}, ${address}`;
  data.FullName = FullName;
  data.Phone = Number(Phone);
  data.AdditionalPhone = Number(AdditionalPhone);
  data.HandlingReason = HandlingReason;
  data.Coment = Coment;
  data.SelectedTariffs = selecrTarrifs.join(", ");
  postRequest("UsersDatas");
  changeStepBid("completion");
};

const newReqest = () => {
  data = {};
  activeCity = "";
  address = "";
  FullName = "";
  Phone = "";
  AdditionalPhone = "";
  HandlingReason = "";
  Coment = "";
  selecrTarrifs = [];
  changeStepBid("customerData");
};

const completionsReqest = () => {
  data.EarlyCompletionPhone = Number(Phone);
  data.EarlyCompletionCause = document.getElementById(
    "EarlyCompletionCause"
  ).value;
  data.OtherInformation = document.getElementById("OtherInformation").value;
  postRequest("EarlyCompletions");
  Phone = "";
  data = {};
  changeStepBid("customerData");
};

const transitionConfirmation = () => {
  isLoad = true;
  let checkboxes = document.querySelectorAll("input[type=checkbox]:checked");
  ``;

  for (let i = 0; i < checkboxes.length; i++) {
    selecrTarrifs.push(checkboxes[i].id);
  }
  isLoad = false;
  changeStepBid("selectConfirmation");
};

function RenderForms() {
  let fieldsForm = ``;

  switch (stepBid) {
    case "customerData":
      fieldsForm = `
        <div class="form__block">
          <label class="form__label" for="city">*Выберите город:</label>
          <select class="form__input" id="city">
              <option disabled selected value> -- Выберите город -- </option>
              <option value="Moscow">Москва</option>
              <option value="Krasnoyarsk">Красноярск</option>
              <option value="Voronezh">Воронеж</option>
              <option value="Sochi">Сочи</option>
          </select>
        </div>

          <div class="form__block">
            <label class="form__label" for="FullName">*ФИО:</label>
            <input class="form__input" value="${FullName}" type="text" id="FullName" name="FullName">
            <span>заполните поле</span>
          </div>

          <div class="form__block">
            <label class="form__label" for="address">*Адрес:</label>
            <input class="form__input" value="${address}" type="text" id="address">
            <span>заполните поле</span>
          </div>

          <div class="form__block">
            <label class="form__label" for="Phone">*Телефон:</label>
            <input class="form__input" value="${Phone}" type="tel" maxlength="11" id="Phone" name="Phone">
            <span>заполните поле</span>
          </div>

          <div class="form__block">
            <label class="form__label" for="AdditionalPhone">Дополнительный телефон:</label>
            <input class="form__input" value="${AdditionalPhone}" type="tel" maxlength="11" id="AdditionalPhone" name="AdditionalPhone">
          </div>

          <div class="form__block">
            <label class="form__label" for="HandlingReason">*Причина обращения:</label>
            <select class="form__input" name="HandlingReason" id="HandlingReason">
            <option disabled selected value> -- Выберите причину обращения -- </option>
                <option value="Не_проведен_интернет">Не проведен интернет</option>
                <option value="Переключение_от_другого_провайдера">Переключение от другого провайдера</option>
                <option value="Выбор_другого_тарифа">Выбор другого тарифа</option>
            </select>
          </div>

          <div class="form__block">
            <label class="form__label" for="address">Комментарий:</label>
            <textarea class="form__input" type="text" id="Coment">${Coment}</textarea>
          <div class="form__block">

          <div class="form__container-button">
            <div class="block-button">
              <p class="block-button__item" onClick="transitionEarlyCompletions()">Досрочное завершение</p>
              <p class="block-button__item" onClick="transitionTariffs()">Перейти к выбору тарифа</p>
            </div>
          </div>
            `;
      break;
    case "selectTariffs":
      fieldsForm = `
      <div class="form__checkbox-list">
        ${
          tariffs.length
            ? `
          ${tariffs
            .map(
              (item) => `
  
                <input class="form__input-checkbox" type="checkbox" id="${item.ServiceName}">
                <label class="form__checkbox-label" for=${item.ServiceName}>${item.ServiceName}</br>${item.ServiceDescription}</br>${item.ServicePrice} рублей</label> 
              `
            )
            .join("")}`
            : `<h1>Нет тарифов для выбранного города</h1>`
        }
        </div>
        <div class="block-button">
          <p class="block-button__item" onClick="changeStepBid('earlyCompletion')">Досрочное завершение</p>
          <p class="block-button__item" onClick="changeStepBid('customerData')">Редактировать данные клиента</p>
          <p class="block-button__item" onClick="transitionConfirmation()">Завершение</p>   
      </div>`;
      break;
    case "selectConfirmation":
      fieldsForm = `
      <h1>Проверьте введеные данные</h1>
        <h3>Город: ${activeCity}</h3>
        <h3>ФИО: ${FullName}</h3>
        <h3>Адрес: ${address}</h3>
        <h3>Контактный телефон: ${Phone}</h3>
        ${
          AdditionalPhone.length
            ? `<h3>Дополнительный телефон: ${AdditionalPhone}</h3>`
            : ""
        }
        <h3>Причина обращения: ${HandlingReason}</h3>
        ${Coment.length ? `<p>Комментарий: ${Coment}</p>` : ""}
        <h1>Выбранные тарифы:</h1>
        ${selecrTarrifs.map((item) => `<p>${item}</p>`).join("")}
        <div class="block-button">
          <p class="block-button__item" onClick="changeStepBid('earlyCompletion')">Досрочное завершение</p>
          <p class="block-button__item" onClick="changeStepBid('selectTariffs')">Изменить тарифы</p>
          <p class="block-button__item" onClick="connectionReqest()">Отправить форму</p>
        </div>
        `;
      break;
    case "completion":
      fieldsForm = `
      <h1>Поблагодарите клиента</h1>
      <div class="block-button">
        <p class="block-button__item" onClick="newReqest()">Новая заявка</p>
      </div>
      `;
      break;
    case "earlyCompletion":
      fieldsForm = `
        <div class="form__block">
          <label class="form__label" for="EarlyCompletionCause">*Причина отказа:</label>
          <select class="form__input" name="EarlyCompletionCause" id="EarlyCompletionCause">
            <option disabled selected value> -- Выберите причину отказа -- </option>
            <option value="Перезвонить_позже">Перезвонить позже</option>
            <option value="Высокая_цена">Высокая цена</option>
            <option value="Плохое_обслуживание">Плохое обслуживание</option>
          </select>
        </div>

        <div class="form__block">
          <label class="form__label" for="OtherInformation">Дополнительный комментарий:</label>
          <textarea class="form__input" type="text" id="OtherInformation" name="OtherInformation"></textarea>
        </div>
        <div class="block-button">
          <p class="block-button__item" onClick="completionsReqest()">Отправить форму отказа</p>
        </div>
        `;
      break;
  }
  if (isLoad) {
    return `<p>Loading</p>`;
  } else
    return `
    <form class="form">
        ${fieldsForm}
    </form>`;
}

function update() {
  document.querySelector("#app").innerHTML = RenderForms();
}
update();

window.changeStepBid = changeStepBid;
window.transitionTariffs = transitionTariffs;
window.transitionConfirmation = transitionConfirmation;
window.transitionEarlyCompletions = transitionEarlyCompletions;
window.connectionReqest = connectionReqest;
window.newReqest = newReqest;
window.completionsReqest = completionsReqest;
