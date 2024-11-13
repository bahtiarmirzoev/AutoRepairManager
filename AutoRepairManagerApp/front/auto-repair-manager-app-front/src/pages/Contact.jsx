import React from "react";

const serviceLocations = [
  {
    name: "Автосервис Darnagul",
    address: "г. Баку, ул. Низами, 45",
    phone: "+994 55 123 4567",
    hours: "Пн-Пт: 9:00 - 19:00, Сб: 10:00 - 16:00",
  },
  {
    name: "Автосервис Yasamal",
    address: "г. Баку, ул. Азадлыг, 23",
    phone: "+994 55 234 5678",
    hours: "Пн-Сб: 8:00 - 18:00",
  },
  {
    name: "Автосервис Narimanov",
    address: "г. Баку, проспект Гейдара Алиева, 10",
    phone: "+994 55 345 6789",
    hours: "Пн-Пт: 9:00 - 19:00, Сб: 10:00 - 15:00",
  },
];

const Contacts = () => {
  return (
    <div className="p-20 bg-gradient-to-b from-gray-200 via-gray-100 to-white text-gray-800">
      {/* Заголовок страницы */}
      <section className="mb-16 text-center">
        <h1 className="text-5xl font-bold mb-6 text-gray-900 tracking-wide">
          Контакты
        </h1>
        <p className="text-lg max-w-3xl mx-auto leading-relaxed text-gray-700">
          Свяжитесь с нами или посетите один из наших автосервисов в вашем
          городе.
        </p>
      </section>

      {/* Карта Google с параллакс-эффектом */}
      <section className="relative mb-16">
        <h2 className="text-4xl font-semibold mb-8 text-center text-gray-900">
          Наше расположение
        </h2>
        <div className="relative w-full max-w-5xl mx-auto shadow-2xl rounded-lg overflow-hidden">
          <div className="absolute inset-0 bg-gradient-to-r from-blue-300 via-transparent to-blue-300 opacity-30 z-10"></div>
          <iframe
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1151.093304486931!2d49.85127228807609!3d40.41430805229083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x403087fbef6b3dfb%3A0xc32b1d5765759234!2sSTEP%20IT%20Komp%C3%BCter%20Akademiyas%C4%B1%20Darnagul!5e0!3m2!1sru!2saz!4v1731141074417!5m2!1sru!2saz"
            width="100%"
            height="400"
            style={{ border: 0 }}
            allowFullScreen=""
            loading="lazy"
            referrerPolicy="no-referrer-when-downgrade"
            title="Google Map"
          ></iframe>
        </div>
      </section>

      {/* Список автосервисов */}
      <section>
        <h2 className="text-4xl font-semibold mb-8 text-center text-gray-900">
          Наши автосервисы
        </h2>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-12 max-w-6xl mx-auto">
          {serviceLocations.map((location, index) => (
            <div
              key={index}
              className="bg-white p-6 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300"
            >
              <h3 className="text-2xl font-bold mb-4 text-gray-800">
                {location.name}
              </h3>
              <p className="text-gray-600">
                <span className="font-semibold">Адрес:</span> {location.address}
              </p>
              <p className="text-gray-600">
                <span className="font-semibold">Телефон:</span> {location.phone}
              </p>
              <p className="text-gray-600">
                <span className="font-semibold">Часы работы:</span>{" "}
                {location.hours}
              </p>
            </div>
          ))}
        </div>
      </section>
    </div>
  );
};

export default Contacts;
