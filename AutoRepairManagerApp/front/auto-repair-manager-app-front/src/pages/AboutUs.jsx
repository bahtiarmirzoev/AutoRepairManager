import React from "react";

const AboutUs = () => {
  return (
    <div className="p-10 bg-gradient-to-b from-gray-200 via-gray-100 to-white text-gray-800">
      {/* Секция "О компании" */}
      <section className="mb-16 text-center">
        <h1 className="text-5xl font-bold mb-6 text-gray-900 tracking-wide">
          О нас
        </h1>
        <p className="text-lg max-w-3xl mx-auto leading-relaxed text-gray-700">
          Мы - команда экспертов в области автосервиса, стремящаяся предоставить
          клиентам высочайшее качество обслуживания и уверенность в надежности
          их транспортных средств. Наш приоритет — индивидуальный подход и
          превосходные результаты.
        </p>
      </section>

      {/* Карта Google с декоративной тенью и эффектом параллакса */}
      <section className="relative mb-16">
        <h2 className="text-4xl font-semibold mb-8 text-center text-gray-900">
          Наше местоположение
        </h2>
        <div className="relative w-full max-w-5xl mx-auto shadow-2xl rounded-lg overflow-hidden">
          <div className="absolute inset-0 bg-gradient-to-r from-indigo-300 via-transparent to-purple-300 opacity-30 z-10"></div>
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

      {/* Секция преимуществ с анимацией при наведении */}
      <section className="mb-16">
        <h2 className="text-4xl font-semibold mb-8 text-center text-gray-900">
          Наши преимущества
        </h2>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-12 max-w-6xl mx-auto">
          <div className="bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300">
            <h3 className="text-2xl font-bold mb-4 text-gray-800">
              Квалифицированные специалисты
            </h3>
            <p>
              Наши сотрудники имеют высокую квалификацию и многолетний опыт
              работы, что позволяет выполнять услуги на высшем уровне.
            </p>
          </div>
          <div className="bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300">
            <h3 className="text-2xl font-bold mb-4 text-gray-800">
              Современное оборудование
            </h3>
            <p>
              Мы используем только самое современное оборудование,
              обеспечивающее точность диагностики и обслуживания.
            </p>
          </div>
          <div className="bg-white p-8 rounded-lg shadow-md transform hover:scale-105 transition-transform duration-300">
            <h3 className="text-2xl font-bold mb-4 text-gray-800">
              Индивидуальный подход
            </h3>
            <p>
              Мы предоставляем персонализированные решения каждому клиенту,
              чтобы наилучшим образом удовлетворить их потребности.
            </p>
          </div>
        </div>
      </section>
    </div>
  );
};

export default AboutUs;
