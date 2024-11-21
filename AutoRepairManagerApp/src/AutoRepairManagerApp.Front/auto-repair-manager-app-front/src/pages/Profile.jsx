import React from "react";

const Profile = () => {
  return (
    <div className="min-h-screen bg-gray-100 flex items-center justify-center py-10 px-4">
      <div className="bg-white shadow-md rounded-lg w-full max-w-4xl p-6">
        {/* Profile Header */}
        <div className="flex flex-col md:flex-row items-center justify-between border-b pb-6">
          <div className="flex items-center space-x-4">
            <img
              src="https://via.placeholder.com/150"
              alt="Profile"
              className="w-24 h-24 rounded-full shadow"
            />
            <div>
              <h1 className="text-2xl font-bold text-gray-800">John Doe</h1>
              <p className="text-sm text-gray-500">Software Engineer</p>
            </div>
          </div>
          <button className="mt-4 md:mt-0 px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700">
            Edit Profile
          </button>
        </div>

        {/* Profile Details */}
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mt-6">
          <div>
            <h2 className="text-lg font-semibold text-gray-700">
              User Details
            </h2>
            <ul className="mt-4 space-y-2 text-gray-600">
              <li>
                <strong>Email:</strong> john.doe@example.com
              </li>
              <li>
                <strong>Phone:</strong> +123 456 7890
              </li>
              <li>
                <strong>Address:</strong> 123 Street, City, Country
              </li>
              <li>
                <strong>Member Since:</strong> January 2023
              </li>
            </ul>
          </div>

          {/* Recent Activity */}
          <div>
            <h2 className="text-lg font-semibold text-gray-700">
              Recent Activity
            </h2>
            <ul className="mt-4 space-y-2 text-gray-600">
              <li>✅ Completed Project A</li>
              <li>📅 Scheduled Meeting with Team B</li>
              <li>📝 Updated Resume</li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
