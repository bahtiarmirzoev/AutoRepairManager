import React, { useState } from "react";
import { FaUser, FaEnvelope, FaLock, FaCar } from "react-icons/fa";

function RegistrationPage() {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Form submission logic here
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-900 relative overflow-hidden">
      {/* Background with overlay */}
      <div
        className="absolute inset-0 bg-cover bg-center opacity-30"
        style={{ backgroundImage: "url('/path-to-your-car-image.jpg')" }}
      ></div>
      <div className="absolute inset-0 bg-gradient-to-br from-black via-gray-800 to-gray-900 opacity-80"></div>

      {/* Registration Form */}
      <div className="relative z-10 bg-gray-800 bg-opacity-90 p-8 rounded-lg shadow-xl w-full max-w-md">
        <h2 className="text-3xl font-bold text-center text-yellow-500 flex items-center justify-center mb-6">
          <FaCar className="mr-2" /> Регистрация
        </h2>
        <p className="text-center text-gray-400 mb-4">
          Присоединяйтесь к нашему автосервису и получайте быстрый доступ к
          услугам
        </p>

        <form onSubmit={handleSubmit} className="space-y-4">
          {/* Username Field */}
          <div className="relative">
            <label htmlFor="username" className="text-gray-300">
              Имя пользователя
            </label>
            <div className="flex items-center border border-gray-600 rounded-md bg-gray-700">
              <FaUser className="text-gray-400 mx-3" />
              <input
                type="text"
                id="username"
                name="username"
                value={formData.username}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-300 focus:outline-none"
                placeholder="Введите имя пользователя"
                required
              />
            </div>
          </div>

          {/* Email Field */}
          <div className="relative">
            <label htmlFor="email" className="text-gray-300">
              Email
            </label>
            <div className="flex items-center border border-gray-600 rounded-md bg-gray-700">
              <FaEnvelope className="text-gray-400 mx-3" />
              <input
                type="email"
                id="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-300 focus:outline-none"
                placeholder="Введите email"
                required
              />
            </div>
          </div>

          {/* Password Field */}
          <div className="relative">
            <label htmlFor="password" className="text-gray-300">
              Пароль
            </label>
            <div className="flex items-center border border-gray-600 rounded-md bg-gray-700">
              <FaLock className="text-gray-400 mx-3" />
              <input
                type="password"
                id="password"
                name="password"
                value={formData.password}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-300 focus:outline-none"
                placeholder="Введите пароль"
                required
              />
            </div>
          </div>

          {/* Confirm Password Field */}
          <div className="relative">
            <label htmlFor="confirmPassword" className="text-gray-300">
              Подтвердите пароль
            </label>
            <div className="flex items-center border border-gray-600 rounded-md bg-gray-700">
              <FaLock className="text-gray-400 mx-3" />
              <input
                type="password"
                id="confirmPassword"
                name="confirmPassword"
                value={formData.confirmPassword}
                onChange={handleChange}
                className="w-full px-4 py-2 bg-transparent text-gray-300 focus:outline-none"
                placeholder="Подтвердите пароль"
                required
              />
            </div>
          </div>

          <button
            type="submit"
            className="w-full py-2 mt-4 bg-yellow-500 text-gray-900 rounded-md font-semibold hover:bg-yellow-600 transition duration-200"
          >
            Зарегистрироваться
          </button>
        </form>

        <p className="text-center text-gray-500 mt-4">
          Уже зарегистрированы?{" "}
          <a href="/login" className="text-yellow-500 hover:underline">
            Войдите
          </a>
        </p>
      </div>
    </div>
  );
}

export default RegistrationPage;
