import React, { useState } from "react";
import { FaUserCircle } from "react-icons/fa";
import { Link } from "react-router-dom";
const Navbar = () => {
  return (
    <nav className="bg-white shadow-lg fixed w-full z-10">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center h-16">
          <div className="flex-shrink-0">
            <Link to="/" className="text-2xl font-bold text-blue-600">
              Paputu Service
            </Link>
          </div>

          <div className="hidden md:flex space-x-8">
            <Link
              to="/"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Главная
            </Link>
            <Link
              to="/Services"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Услуги
            </Link>
            <Link
              to="/AboutUs"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              О нас
            </Link>
            <Link
              to="/Contact"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Контакты
            </Link>
          </div>

          <div className="flex items-center space-x-4">
            <Link
              to="/LoginPage"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Вход
            </Link>
            <Link
              to="/RegistrationPage"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Регистрация
            </Link>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
