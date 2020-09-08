# Bank-Balance
Event source demo

# Endpoint to get current balance
GET: http://localhost:5000/balance

# Endpoint to insert money
POST: http://localhost:5000/insert/money
Body: {
    "Amount" : 350
}

# Endpoint to withdraw money
POST: http://localhost:5000/withdraw/money
Body: {
    "Amount" : 230
}
