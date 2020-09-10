# Bank-Balance
Event source demo

# Endpoint to get current balance
GET: http://localhost:5000/balance

# Endpoint to get operations count
GET: http://localhost:5000/operations/count

# Endpoint to get the largest amount of withdrawn money
GET: http://localhost:5000/max/withdrawn/amount

# Endpoint to top up money
POST: http://localhost:5000/top/up/money
Body: {
    "Amount" : 350
}

# Endpoint to withdraw money
POST: http://localhost:5000/withdraw/money
Body: {
    "Amount" : 230
}
