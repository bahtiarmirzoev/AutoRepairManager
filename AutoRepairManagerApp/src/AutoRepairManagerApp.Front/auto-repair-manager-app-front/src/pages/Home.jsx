import React from "react";
import {
  FaOilCan,
  FaWrench,
  FaCarCrash,
  FaUserShield,
  FaBatteryFull,
  FaCogs,
} from "react-icons/fa";
import { Link } from "react-router-dom";

const Home = () => {
  return (
    <div className="bg-gray-100 text-gray-800">
      {/* Services Section with Interactive Cards */}
      <section className="py-16 bg-white">
        <div className="max-w-6xl mx-auto text-center mb-12">
          <h2 className="text-4xl font-bold text-gray-900">Наши Услуги</h2>
          <p className="text-lg text-gray-700 mt-4">
            Мы предлагаем широкий спектр профессиональных услуг для вашего
            автомобиля.
          </p>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-10 px-8">
          {[
            { icon: <FaOilCan />, title: "Замена масла" },
            { icon: <FaWrench />, title: "Ремонт двигателя" },
            { icon: <FaCarCrash />, title: "Кузовной ремонт" },
            { icon: <FaUserShield />, title: "Диагностика" },
            { icon: <FaBatteryFull />, title: "Замена аккумулятора" },
            { icon: <FaCogs />, title: "Техническое обслуживание" },
          ].map((service, index) => (
            <div
              key={index}
              className="bg-gray-200 p-6 rounded-lg shadow-md hover:shadow-2xl transform hover:scale-105 transition-transform duration-300 flex flex-col items-center"
            >
              <div className="text-4xl text-blue-600 mb-4">{service.icon}</div>
              <h3 className="text-2xl font-semibold text-gray-900 mb-2">
                {service.title}
              </h3>
              <p className="text-gray-600 text-center">
                Обслуживание на высшем уровне для безопасности вашего
                автомобиля.
              </p>
            </div>
          ))}
        </div>
      </section>

      <section className="py-16 bg-gray-100">
        <div className="max-w-6xl mx-auto text-center mb-12">
          <h2 className="text-4xl font-bold text-gray-900">
            Отзывы наших клиентов
          </h2>
          <p className="text-lg text-gray-700 mt-4">
            Наши клиенты довольны качеством обслуживания и результатом.
          </p>
        </div>

        <div className="flex overflow-x-auto space-x-6 px-8 snap-x snap-mandatory">
          {[
            "Отличный сервис!",
            "Профессиональный подход",
            "Быстро и качественно",
            "Metreynen ish goreller? PAPUTU ",
          ].map((review, index) => (
            <div
              key={index}
              className="bg-white min-w-[300px] max-w-[350px] p-6 rounded-lg shadow-lg snap-center"
            >
              <p className="text-lg font-semibold mb-2 text-gray-800">
                {review}
              </p>
              <p className="text-gray-600">
                Работа была выполнена быстро и качественно. Очень доволен
                результатом!
              </p>
              <span className="text-sm text-gray-500 mt-4 block">
                — Клиент {index + 1}
              </span>
            </div>
          ))}
        </div>
      </section>

      <section className="py-16 bg-blue-600 text-white">
        <div className="max-w-6xl mx-auto text-center mb-12">
          <h2 className="text-4xl font-bold">Свяжитесь с нами</h2>
          <p className="text-lg mt-4">
            Мы всегда рады помочь вам с любыми вопросами. Узнайте, как с нами
            связаться на странице контактов.
          </p>
        </div>
        <div className="text-center">
          <Link
            to="/contact"
            className="bg-white text-blue-600 px-6 py-3 rounded-lg font-semibold hover:bg-gray-100 transition duration-300"
          >
            Перейти на страницу контактов
          </Link>
        </div>
      </section>
    </div>
  );
};

export default Home;
