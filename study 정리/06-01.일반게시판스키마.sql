-- 일반 게시판 스키마(데이터 저장 구조) 생성

--. 1. 제거 - drop table, drop sequence : 순서는 상관없음.
--   cascade : 묻지도 따지지도 말고. CONSTRAINTS : 제약
--   table : 데이터를 저장하기 위한 구조
drop table board CASCADE CONSTRAINTS;
--   sequence : 순서 번호
drop sequence board_seq;


-- 2. 생성 - create table, create sequence : 순서는 상관없음.
--   varchar2 - 4000byte까지 저장. 길이 필수
--   no null : 필수 입력. primary key : 주키 - not null + unique
--   sysdate : 시스템의 현재 날짜와 시간 데이터
--   hit : 기본값을 사용한 이유 - hit에 데이터가 없으면 null이 된다.
--     : null 연산 불가. hit = hit + 1
create table board(
  no number CONSTRAINT board_no_pk primary key,
  title VARCHAR2(300) not null,
  content VARCHAR2(2000) not null,
  writer VARCHAR2(30) not null,
  writeDate date default sysdate,
  hit NUMBER default 0,
  pw VARCHAR2(20)
);

create sequence board_seq;

-- 3. 샘플데이터
--   seq.nextval -> 다음 숫자를 받아온다. 숫자가 계속 증가. 보통 20개씩 만들어 둔다.
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '게시판', '게시판입니다.', '홍길동', '1111');
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '유용한 데이터 공유', '게시판입니다.', '관리자', '1111');
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '메시 승', '신의 대관식.', '박지성', '1111');
commit;

-- 4. 데이터 검사.
--   * : 모든 데이터 표시 -> 속도가 느려지는 원인이 되기 때문에 현장에는 사용안한다.
select * from board;