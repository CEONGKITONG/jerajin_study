<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<h1>게시판 리스트</h1>
<div onclick='location="view.do?no=1&inc=1"'>1. 게시판입니다. 홍길동 2023.04.07 - 1000</div>
<a href="write.do">글쓰기</a>
<div>${list }</div>
</body>
</html>