### STAGE 1: Build ###
FROM node:13.1.0  AS build
WORKDIR /usr/src/app

COPY package.json package-lock.json ./
RUN npm install
COPY . .

RUN npm run build-prod
### STAGE 2: Run ###
FROM nginx:1.17.1-alpine

COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/JudoSystem /usr/share/nginx/html
EXPOSE 80

